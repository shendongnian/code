    protected string DisplayUser { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        DirectoryEntry de = GetUser("dramirez");
        if (de != null)
        {
            DisplayUser = de.Properties["displayName"].Value.ToString();
        } 
    }
