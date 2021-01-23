    public string _hello;
    [WebBrowsable(true), Category("category"), Personalizable(PersonalizationScope.Shared), WebDisplayName("Hello"), WebDescription("Description1")]
    public string hello
    {
        get { return _hello; }
        set { _hello = value; }
    }
