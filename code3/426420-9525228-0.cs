    IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
    
    public MainPage()
    {
        InitializeComponent();
        createStorage();
    }
    public void createStorage()
    {
        if (!settings.Contains("init"))
        {
	    settings.Add("x", "randomtext");
            settings.Add("init", true);
        }      
    }
