    protected DAL DAL { get; private set; }
    
    public void Init()
    {
          var manager = new SettingsManager();
    
          DAL = new DAL(manager.ReadSettings(@"C:\settings\settings.config"));
    }
