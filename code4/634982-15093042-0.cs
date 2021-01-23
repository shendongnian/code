    public string Exclusions;
    [Category("Extended Settings"),
    Personalizable(PersonalizationScope.Shared),
    WebBrowsable(true),
    WebDisplayName("Library Exclusions"),
    WebDescription("Enter any Libraries to exclude. Use '|' to separate.")]
    public string _Exclusions
    {
        get { return Exclusions; }
        set
        { Exclusions = value;}
    }
