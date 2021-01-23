        #region Properties
        public ViewModel ViewModel
        {
            get { return (ViewModel)ViewModel; }
            set { base.ViewModel = value; }
        }
        #endregion
        #region Constructor
        public LoginView()
        {
            InitializeComponent();
            Loaded += View_Loaded;
        }
        #endregion
        #region Events
        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.SomeEventOrProperty //blah you get it
        }
        #endregion
