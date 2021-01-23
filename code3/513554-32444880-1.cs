    public bool IsPageRefresh 
    {
        get
        {
            return !string.IsNullOrEmpty(Request.QueryString["loaded"]);
        }
    }
