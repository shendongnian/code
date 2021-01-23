    // Store the current site context name
    string oldSiteName = Sitecore.Context.GetSiteName();
    // Change the website context
    Sitecore.Context.SetActiveSite("website");
    
    // Generate the link
    string url = LinkManager.GetItemUrl(item);
    // Change back to the old site context
    Sitecore.Context.SetActiveSite(oldSiteName);
