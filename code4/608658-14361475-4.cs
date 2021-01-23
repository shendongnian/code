    public int MyClassProperty
    {
        get
        {
            return Settings.Instance.GetProperty("MyClassProperty");
        }
        set
        {
            Settings.Instance.SetProperty("MyClassProperty", value);
        }
    }
