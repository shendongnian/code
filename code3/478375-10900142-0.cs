    public SettingsPage()
    {
        ViewModel = new ViewModel();
        InitializeComponent();
    }
    
    private ViewModel ViewModel
    {
        get { return DataContext as ViewModel; }
        set { DataContext = value; }
    }
