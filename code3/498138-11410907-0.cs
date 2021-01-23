    using(var site = new SPSite("urltolist"))
    {
    	var list = site.RootWeb.Lists["List"];
    	foreach(var li in list.Items.Cast<SPListItem>().Reverse())
    	{
    		// Display entries
    	}
    }
