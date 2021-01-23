    private bool HasChanged
    {
        get { object b = ViewState["HasChanged"] ?? false; return (bool)b; }
        set { ViewState["HasChanged"] = value; }
    }
