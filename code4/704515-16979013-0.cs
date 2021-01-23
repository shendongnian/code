    SPWeb web = properties.Feature.Parent as SPWeb;
    PublishingWeb pWeb = PublishingWeb.GetPublishingWeb(web);
    foreach (PublishingPage page in pWeb.GetPublishingPages())
    {
        if (page.Name.Equals("myPage.aspx"))
        {
            // Do your stuff here
        }
    }
