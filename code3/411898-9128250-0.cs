            var reader = XmlReader.Create("http://bbaremancareers.wordpress.com/feed/");
	        var feed = SyndicationFeed.Load<SyndicationFeed>(reader);
	
	        Console.WriteLine("Latest posts from " + feed.Title.Text);
	
	        foreach (var item in feed.Items)
	        {
	            string strTitle = item.Title.Text;
	            string strContent = item.Summary.Text;
				DateTime publishDate = item.PublishDate.DateTime;
				string linkUrl = item.Links[0].Uri.ToString();
	        }
