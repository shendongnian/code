	public void ParseDetails()
	{
		Parallel.ForEach(mListAppInfo.ToArray(), ai => ParseOneDetail(ai));
	}
	
	private void ParseOneDetail(ApplicationInfo appInfo)
	{
		var htmlWeb = new HtmlWeb();
		var document = htmlWeb.Load(appInfo.AppAnnieURL);
	
		// get first one only
		HtmlNode nodeStoreURL = 
				document.DocumentNode.SelectSingleNode(Constants.XPATH_FIRST);
		appInfo.StoreURL = nodeStoreURL.Attributes[Constants.HREF].Value;
	}
