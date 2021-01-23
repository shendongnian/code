    [ConfigurationProperty("mode", IsRequired = true, DefaultValue = "discardnew")]
    [RegexStringValidator("^(?i)(discardnew|discardold)$")]
    public string Mode
    {
        get { return (string)base["mode"]; }
        set { base["mode"] = value; }
    }
