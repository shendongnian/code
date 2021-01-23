     using (SPWeb web = site.OpenWeb(HttpUtility.UrlDecode(webUri.AbsolutePath)))
                {
                    PublishingWeb pWeb = null;
    
                    if (!web.Exists || !PublishingWeb.IsPublishingWeb(web))
                    {
                      return;
                    }
    
                    pWeb = PublishingWeb.GetPublishingWeb(web);
                    PublishingPageCollection publishingPages = publishingWeb.GetPublishingPages();
                    foreach (PublishingPage publishingPage in publishingPages)
                    {
                       //do something here with publishingPage.Layout
                    }               
                }
