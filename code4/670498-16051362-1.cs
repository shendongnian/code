        public MainWindow()
        {
            InitializeComponent();
            ViewModel.MainViewModel = new ViewModel();
            DataContext = ViewModel.MainViewModel;
        }
