    public string SelectedProductName 
    {
        get { return (string)Session["SelectedProductName"]; }
        set { Session["SelectedProductName"] = value;
    }
