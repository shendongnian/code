    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();            
        }
        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            SubWindow subWindow = new SubWindow();
            subWindow.Show();
        }
    }
