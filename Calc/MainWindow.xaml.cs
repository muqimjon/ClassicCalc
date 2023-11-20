using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Calc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool equalized;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonNumber(object sender, RoutedEventArgs e)
        {
            if (equalized)
                Oyna.Content = "0";

            if (Oyna.Content is not null)
            {
                var buttonContent = (sender as Button)?.Content?.ToString();
                Oyna.Content = Oyna.Content!.ToString() == "0" ? buttonContent : Oyna.Content + buttonContent;
            }

            equalized = false;
        }

        private void ButtonDot(object sender, RoutedEventArgs e)
        {
            if (equalized)
                Oyna.Content = "0";

            if (Oyna.Content is not null)
                Oyna.Content += ".";
            equalized = false;
        }

        private void ButtonAdd(object sender, RoutedEventArgs e)
        {
            if (Oyna.Content is not null && Oyna.Content!.ToString() != "0")
                Oyna.Content += "+";
            equalized = false;
        }

        private void ButtonSubtract(object sender, RoutedEventArgs e)
        {
            if (Oyna.Content is not null && Oyna.Content!.ToString() != "0")
                Oyna.Content += "-";
            equalized = false;
        }

        private void ButtonDivide(object sender, RoutedEventArgs e)
        {
            if (Oyna.Content is not null && Oyna.Content!.ToString() != "0")
                Oyna.Content += "/";
            equalized = false;
        }

        private void ButtonMultiple(object sender, RoutedEventArgs e)
        {
            if (Oyna.Content is not null && Oyna.Content!.ToString() != "0")
                Oyna.Content += "*";
            equalized = false;
        }

        private void ButtonClean(object sender, RoutedEventArgs e)
        {
            Oyna.Content = "0";
            equalized = false;
        }

        private void ButtonBackSpace(object sender, RoutedEventArgs e)
        {
            if (Oyna.Content is null)
                return;

            var content = Oyna.Content.ToString();
            Oyna.Content = content!.Substring(0, content.Length - 1);

            if (Oyna.Content!.ToString() == "")
                Oyna.Content = "0";
            equalized = false;
        }

        private void ButtonEqual(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            Oyna.Content = dt.Compute(Oyna.Content.ToString(), "");
            equalized = true;
        }
    }
}