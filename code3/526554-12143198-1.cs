    using (var conn = new DataConnection())
    {
        Guid pageTypeIdInQuestion = Guid.Empty; // put type id here
    
        var siteMapNav = new SitemapNavigator(conn);
        var pagesOfDesiredType = conn.Get<IPage>().Where(f => f.PageTypeId == pageTypeIdInQuestion).Select(f => f.Id);
        var pages = siteMapNav.CurrentHomePageNode.GetPageNodes(SitemapScope.DescendantsAndCurrent).Where(f=> pagesOfDesiredType.Contains(f.Id));
    }
