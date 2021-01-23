    private static <whatevertype> webDB;
    private static <whatevertype> item;
    public void GetConfiguration()
    {
        if (webDB == null)
        {
            webDB = Sitecore.Configuration.Factory.GetDatabase("web");
    
            if (item != null)
                item = webDB.Items[StartItem];
        }
    }
