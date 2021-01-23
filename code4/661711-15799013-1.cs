    public partial class MainWindow : Window
    {
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).MyClassInstance.Method();
        }
    }
