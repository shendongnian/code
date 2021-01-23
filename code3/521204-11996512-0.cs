    using System.ServiceModel.Syndication;
    
    public bool TryParseFeed(string Url)
    {
    	try
    	{
    		SyndicationFeed feed = SyndicationFeed.Load(XmlReader.Create(Url));
    
    		foreach (SyndicationItem item in feed.Items)
    		{
    			Debug.Print(item.Title.Text);
    		}
    		return true;
    	}
    	catch (Exception)
    	{
    		return false;
    	}
    }
