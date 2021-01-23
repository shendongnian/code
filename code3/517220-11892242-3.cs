    var wc = new WebClient();
    
    wc.DownloadStringCompleted += (s, e) =>
    {
        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        doc.LoadHtml(e.Result);
        var link = doc.DocumentNode
                        .SelectSingleNode("//span[@class='message-profile-name']")
                        .Element("a")
                        .Attributes["href"].Value;
    };
    wc.DownloadStringAsync(new Uri("http://chatroll.com/rotternet"));
  
