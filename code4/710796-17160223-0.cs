    IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
    // Constructor
    public MainPage()
    {
        InitializeComponent();
        if (!settings.Contains("masterPass"))
        {
            // set a default
            settings.Add("masterPass", "0000");
            settings.Save();
        }
    }
