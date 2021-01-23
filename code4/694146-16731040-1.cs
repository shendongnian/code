    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this, "Text", "Caption", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
