    // constructor
    private PageStyle()
    {
        if (webDB != null)
        {
            webDB = Sitecore.Configuration.Factory.GetDatabase("web");
            Sitecore.Data.Items.Item item = webDB.Items[StartItem];
        }
    }
