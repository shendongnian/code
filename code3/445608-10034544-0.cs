    public string StringVariable { get; set; }
    public string SettingValue
    {
        get { return ConfigurationManager.AppSettings[StringVariable]; }
    }
