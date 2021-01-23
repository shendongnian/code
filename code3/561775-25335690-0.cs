    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
    
            Loaded += MainWindow_Loaded;
        }
    
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            AeroResourceInitializer.Initialize();
        }
    }
