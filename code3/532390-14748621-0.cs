    private void Navigated(object sender, NavigationEventArgs navigationEventArgs)
	{
		var browser = sender as WebBrowser;
		if(browser != null)
		{
			var doc = AssociatedObject.Document as HTMLDocument;
			if (doc != null)
			{
				if (doc.url.StartsWith("res://ieframe.dll"))
				{
					// Do stuff to handle error navigation
				}
			}
		}
	}
