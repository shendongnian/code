    public string Name
    {
        get { 
            Configuration conf = ConfigurationManager.OpenExeConfiguration("library.dll");
            return conf.AppSettings.Settings["House"].Value; 
        }
    }
