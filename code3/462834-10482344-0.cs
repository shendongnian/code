    public class Parameter 
    { 
    private string thevalue;
    [Browsable(false)]
    public bool CanEditValue { get; set; }
    [Description("the name")] 
    public string Name { get; set; } 
    [Description("the description")] 
    public string Description { get; set; } 
    [Description("the value"), ReadOnly(true)] 
    public string Value { 
        get { return this.thevalue; }
        set { if (this.CanEditValue) this.thevalue = value; } 
    }
    }
