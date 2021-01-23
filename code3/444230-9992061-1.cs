    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("KeyDown");
            System.Diagnostics.Debug.WriteLine(e.Key);
        }
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("PreviewKeyDown");
            System.Diagnostics.Debug.WriteLine(e.Key);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Button clicked");
        }
    }
