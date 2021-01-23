    public string UserName { get; set; }
    public string[] UserNameSeparated
    {
        get { Username.Split('-'); }
        set
        {
            UserName = String.Join("-", value);
        }
    }
