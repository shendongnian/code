    public partial class Window1 : Window
    {
        private MainWindow mainWindow;
        public Window1(MainWindow mainWindow)
        {
            if (mainWindow == null) {
                throw new ArgumentNullException("mainWindow");
            }
            this.mainWindow = mainWindow;
            InitializeComponent();
        }
        private void btnRetry_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Connect();
        }
        // ...
    }
