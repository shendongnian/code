    public partial class MainWindow : Window
    {
        private ViewModel mainViewModel = null;
        public MainWindow()
        {
            InitializeComponent();
            mainViewModel = new ViewModel();
            this.DataContext = mainViewModel;
            mainViewModel.RequestClose += delegate(object sender, EventArgs args) { this.Close(); };
        }
    }
