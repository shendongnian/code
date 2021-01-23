    private Headers _hdrs;
    public Headers Hdrs 
    {
        get
        {
            return _hdrs ?? (_hdrs = new Headers());
        }
    }
    public DataRowView DataRowItem { get; set; }
