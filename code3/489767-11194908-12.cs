    var document = XDocument.Parse(feedContents);
    var posts = (from p in document.Descendants("item")
                 select new
                 {
                     Title = p.Element("title").Value,
                     Link = p.Element("link").Value,
                     Comments = p.Element("comments").Value,
                     PubDate = DateTime.Parse(p.Element("pubDate").Value)
                 }).ToList();
