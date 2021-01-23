    public partial class TestWindow : Window
    {
        object obj;
        public TestWindow()
        {
            InitializeComponent();
    
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            obj = new object();
        }
    }
