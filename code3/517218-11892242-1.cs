    using (var wc = new WebClient())
    {
        string page = wc.DownloadString("http://chatroll.com/rotternet");
        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        doc.LoadHtml(page);
                                    
        var link = doc.DocumentNode
                      .SelectSingleNode("//span[@class='message-profile-name']")
                      .Element("a")
                      .Attributes["href"].Value;
    }
  
