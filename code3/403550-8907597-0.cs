    private PageStyle()
    {
        if (webDB != null)
        {
            webDB = Sitecore.Configuration.Factory.GetDatabase("web");
            this.item = webDB.Items[StartItem];
        }
    }
