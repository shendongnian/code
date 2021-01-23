    public int? MyClassProperty
    {
        get
        {
            return (int?)Settings.Instance.GetProperty("MyClassProperty");
        }
        set
        {
            Settings.Instance.SetProperty("MyClassProperty", value);
        }
    }
