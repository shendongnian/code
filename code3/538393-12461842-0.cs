    using (var site = new SPSite(ApplicationResources.Url.SiteRoot))
    {
        using (var web = site.OpenWeb())
        {
            var page = web.GetFile(ApplicationResources.Url.FullDefaultPageName);
            var item = page.Item;
            item["Wiki Content"] = NewContent(title, text);
            item.Update();
        }
    }
