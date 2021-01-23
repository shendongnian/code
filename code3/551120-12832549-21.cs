        private ChannelListViewModel m_voltageViewModel;
        public MainWindow()
        {
            InitializeComponent();
            m_voltageViewModel = new ChannelListViewModel();
            m_voltageViewModel.Initialize();
            DataContext = m_voltageViewModel;
        }
