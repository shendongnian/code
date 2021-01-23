    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainGrid.DataContext = new MainViewModel();
        }
    }
