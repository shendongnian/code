	XmlReader r = new MyXmlReader(url);
	SyndicationFeed feed = SyndicationFeed.Load(r);
	Rss20FeedFormatter rssFormatter = feed.GetRss20Formatter();
	XmlTextWriter rssWriter = new XmlTextWriter("rss.xml", Encoding.UTF8);
	rssWriter.Formatting = Formatting.Indented;
	rssFormatter.WriteTo(rssWriter);
	rssWriter.Close();
