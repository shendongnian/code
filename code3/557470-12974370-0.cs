    void RetargetFeed()
    {
        string feedLocation = "http://example.com/rssfeed";
        
        // read original feed
        Rss20FeedFormatter rssformat = new Rss20FeedFormatter();
        rssformat.ReadFrom(XmlReader.Create(feedLocation));
        // create a list of items from the rogiinal
        List<SyndicationItem> items = new List<SyndicationItem>();
        items.AddRange(rssformat.Feed.Items);
    
        // add a new item to the end of the list
        items.Add(new SyndicationItem("Test Item", "This is the content for Test Item", new Uri("http://Contoso/ItemOne"), "TestItemID", DateTime.Now));
        // create a new Rss writer
        SyndicationFeed newFeed = new SyndicationFeed(items);
        var writeFormat = new Rss20FeedFormatter(newFeed);
        //and write the output to a file
        writeFormat.WriteTo(XmlWriter.Create("testoutputfile.xml"));
    }
