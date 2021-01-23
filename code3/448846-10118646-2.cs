    var visual = /* unknown */;
    var fd = new FixedDocument();   
    while(loop)
    {
    	var canvas = PageInit();
    	var page = new FixedPage();
    	page.Width = visual.DocumentPaginator.PageSize.Width;
    	page.Height = visual.DocumentPaginator.PageSize.Height;
    	page.Children.Add(canvas);
    
    	PageContent pageContent = new PageContent();
    	((IAddChild)pageContent).AddChild(page);
    	visual.Pages.Add(pageContent);
    }
