        public actionButton()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(actionButton_Loaded);
        }
        void actionButton_Loaded(object sender, RoutedEventArgs e)
        {
            Notify("IsLoaded");
        }
