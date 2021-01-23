    public MainPage()
    {
        InitializeComponent();
        Loaded += (s, e) =>
        {
            InitializeSettings();
            // Some login-password check condition
            if (_login && _password)
                NavigationService.Navigate(new Uri("/Conversation.xaml",
                                                   UriKind.Relative));
        }
    }
