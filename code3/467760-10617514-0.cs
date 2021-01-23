	public MyPage()
	{
		list.ScrolledToEnd += OnScrolledToEnd;
	}
	public void OnScrolledToEnd(object sender, ScrolledToEndEventArgs args)
	{
		list.TriggerScrolledToEndEvents = false; 
		// TODO load more data async. => call OnDataLoaded on loaded
	}
	public void OnDataLoaded()
	{
		// TODO add new items to list
		list.TriggerScrolledToEndEvents = true; 
	}
