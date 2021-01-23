    string pageType = null;
	using (var conn = new DataConnection())
	{
		var currentPageId = HomePageNode.Id;
		var pageTypeId = conn.Get<IPage>().Where( p => p.Id == currentPageId ).Select( p => p.PageTypeId ).Single();
		pageType = conn.Get<IPageType>().Where(pt => pt.Id == pageTypeId ).Select(pt => pt.Name).Single();
	}
