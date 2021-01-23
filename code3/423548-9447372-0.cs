                WebRequest request = WebRequest.Create(this.Url);
                request.Timeout = Timeout;
                using (WebResponse response = request.GetResponse())
                using (XmlReader reader = XmlReader.Create(response.GetResponseStream()))
                {
                    SyndicationFeed feed = SyndicationFeed.Load(reader);
                    if (feed != null)
                    {
                        foreach (var item in feed.Items)
                        {
                             // Work with the Title and PubDate properties of the FeedItem
                        }
                    }
                }
 
