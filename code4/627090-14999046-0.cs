    public string FirstNameFilter 
    {
        get
        {
            return (string)this.ViewState["FirstNameFilter"] ?? string.Empty;
        }
        set
        {
            this.ViewState["FirstNameFilter"] = value;
        }
    }
