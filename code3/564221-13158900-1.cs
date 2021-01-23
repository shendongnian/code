    using (SPSite site = new SPSite(SPContext.Current.Web.Url))
    {
        SPWeb rootWeb = site.RootWeb;
        rootWeb.AllowUnsafeUpdates = true;
        SPList wiki = rootWeb.Lists["Pages"];
        String url = wiki.RootFolder.ServerRelativeUrl.ToString();
        PublishingSite pubSite = new PublishingSite(rootWeb.Site);
        string pageLayoutName = "EnterpriseWiki.aspx"; //Page Layout Name
        string layoutURL = rootWeb.Url + "/_catalogs/masterpage/" + pageLayoutName;
        PageLayout layout = pubSite.PageLayouts[layoutURL];
        PublishingWeb publishingWeb = PublishingWeb.GetPublishingWeb(rootWeb);
        PublishingPage newWikiPage;
        string myWikiPage = "MyWikiPage.aspx"; //Page name
        newWikiPage = publishingWeb.GetPublishingPages().Add(myWikiPage, layout);
        newWikiPage.Title = "My Wiki Page";
        newWikiPage.Update();
        rootWeb.AllowUnsafeUpdates = false;
        rootWeb.Dispose();
    }
