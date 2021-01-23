        public ObservableCollection<string> LstLog { get; set; }
        private ObservableCollection<string> _lstContent = new ObservableCollection<string>();
        public ObservableCollection<string> LstContent
        {
            get
            {
                LstLog.Add("get");
                return _lstContent;
            }
            set
            {
                LstLog.Add("set");
                _lstContent = value;
            }
        }
        public MainWindow()
        {
            LstLog = new ObservableCollection<string>();
            InitializeComponent();
            this.DataContext = this;
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            LstContent.Add("Value added");
        }
        private void New_Click(object sender, RoutedEventArgs e)
        {
            _lstContent = new ObservableCollection<string>();
        }
        private void NewBind_Click(object sender, RoutedEventArgs e)
        {
            _lstContent = new ObservableCollection<string>();
            listObj.ItemsSource = _lstContent;
        }
        private void NewProp_Click(object sender, RoutedEventArgs e)
        {
            LstContent = new ObservableCollection<string>();
        }
        private void NewPropBind_Click(object sender, RoutedEventArgs e)
        {
            LstContent = new ObservableCollection<string>();
            listObj.ItemsSource = LstContent;
        }
