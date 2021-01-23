    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MyBrowser.Navigate(Directory.GetCurrentDirectory() + "/HTMLPage1.html");
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MyBrowser.InvokeScript("selectOption", new String[] { "value3" });
        }
    }
