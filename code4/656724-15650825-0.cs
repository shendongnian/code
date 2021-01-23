       var rssFeed = from el in doc.Elements("rss").Elements("channel").Elements("item")
                   
                     orderby datetime(el.Element("pubDate").Value) descending
                     
                     select new
                     {
                         Title = el.Element("title").Value,
                         Link = el.Element("link").Value,
                         Description =replace_other(el.Element("description").Value),
                         Image= regex(el.Element("description").Value),
                         PubDate = datetime(el.Element("pubDate").Value),
                        
                     };
       lvFeed.DataSource = rssFeed;
       lvFeed.DataBind(); 
   }
     protected string regex(string source)
      {
       var reg1 = new Regex("src=(?:\"|\')?(?<imgSrc>[^>]*[^/].(?:jpg|bmp|gif|png))   
           (?:\"|\')?");
       var match1 = reg1.Match(source);
       if (match1.Success)
       {
           Uri UrlImage = new Uri(match1.Groups["imgSrc"].Value, UriKind.Absolute);
           return UrlImage.ToString();
       }
       else
       {
           return null;
       }
