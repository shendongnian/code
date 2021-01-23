    private ISettings _settings;
    public ISettings Settings
    {
      get { return _settings ?? Settings.Instance;}
      set { _settings = value; }
    }
