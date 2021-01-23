    void webclient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
        if (e.Error != null)
        {
            MessageBox.Show("error");
        }
        // parsing Flickr 
    
        XElement XmlTweet = XElement.Parse(e.Result);
        string ns = "http://www.w3.org/2005/Atom";
    
        XName entry = XName.Get("entry", ns);
        XName loc = XName.Get("loc", ns);
        XName title = XName.Get("title", ns);
        XName published = XName.Get("published", ns);
        XName link = XName.Get("link", ns);
        XName content = XName.Get("content", ns);
        XName url = XName.Get("url", ns);
    
        listBox1.ItemsSource = 
            from tweet in XmlTweet.Elements(entry)
            select new FlickrData
            {
                ImageSource = tweet.Element(link).Attribute("href").Value,
                Message = tweet.Element(content).Value,
                UserName = tweet.Element(title).Value,
                PubDate = DateTime.Parse(tweet.Element(published).Value)
            };
    }
