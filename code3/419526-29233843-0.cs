    XmlReader reader = XmlReader.Create("http://localhost/feeds/serializedFeed.xml");
    SyndicationFeed feed = SyndicationFeed.Load(reader);
    // Feed title
    Console.WriteLine(feed.Title.Text);
    foreach(var item in feed.Items)
    {
        // Each item
        Console.WriteLine("Title: {0}", item.Title.Text);
        Console.WriteLine("Summary: {0}", ((TextSyndicationContent)item.Summary).Text);
    }
