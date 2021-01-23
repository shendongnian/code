    using System.Diagnostics;
    using System.ServiceModel.Syndication;
    using System.Xml;
    public bool TryParseFeed(string url)
    {
    	try
    	{
    		SyndicationFeed feed = SyndicationFeed.Load(XmlReader.Create(url));
    
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
