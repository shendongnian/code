    /// <summary>
    /// Create Wiki Page
    /// </summary>
    /// <param name="wikiPages"></param>
    /// <param name="pageName"></param>
    /// <param name="pageContent"></param>
    /// <returns></returns>
    public static SPListItem CreateWikiPage(SPList wikiPages, string pageName, string pageContent)
    {
       var web = wikiPages.ParentWeb;
       var pSite = new Microsoft.SharePoint.Publishing.PublishingSite(web.Site);
       var pageLayoutUrl = SPUtility.ConcatUrls(web.Site.Url,"/_catalogs/masterpage/EnterpriseWiki.aspx");
       var pageLayout = pSite.PageLayouts[pageLayoutUrl];
       var pWeb = Microsoft.SharePoint.Publishing.PublishingWeb.GetPublishingWeb(web);
       var wikiPage = pWeb.GetPublishingPages().Add(pageName, pageLayout);
       var wikiItem = wikiPage.ListItem;
       wikiItem["PublishingPageContent"] = pageContent;
       wikiItem.Update();
       return wikiItem;
    }
