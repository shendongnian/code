    void SetDefaultPageLayout(string layoutName, SPWeb web)
    {
        var pubWeb = PublishingWeb.GetPublishingWeb(web);
        if (pubWeb != null)
        {
            var pageLayout = pubWeb.GetAvailablePageLayouts()
                .Single(pl => pl.Name == layoutName);
            pubWeb.SetDefaultPageLayout(pageLayout, true);
            pubWeb.Update();
        }
    }
