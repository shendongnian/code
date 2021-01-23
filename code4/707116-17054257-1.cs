    [ScriptIgnore]
    public DateTime DateValue { get; set; }
    public string DateValueJS
    {
        get { return DateValue.ToString("g"); }
    }
