    public MainPage()
    {
        InitializeComponent();
        Loaded += (s, e) =>
        {
            InitializeSettings();
            if (// check for login and password)
                NavigationService.Navigate(new Uri("/Conversation.xaml",
                                                   UriKind.Relative));
        }
    }
