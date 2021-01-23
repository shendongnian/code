    public partial class MainWindow : Window
    {
        TextBlock textBlock = new TextBlock();
        public MainWindow()
        {
            InitializeComponent();
        }
    
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TestWindow testWindow = new TestWindow();
            testWindow.Content = textBlock;
            testWindow.Closing += HandleTestWindowClosing;
            testWindow.Show();
        }
    
        void HandleTestWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var testWindow = sender as TestWindow;
            if(testWindow!=null)
            {
                testWindow.Content = null;
                testWindow.Closing -= HandleTestWindowClosing;
            }
        }
    }
