    public List<string> MyItemsFromViewState
    {
        get { return new List<string>((string[])ViewState["MyItems"]); }
        set { ViewState["MyItems"] = value.ToArray(); }
    }
