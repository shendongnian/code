    //Get data from xml url (This is the code that shuld not run everytime a user visits the view)
    var url = "http://www.interneturl.com/file.xml";
    // Get data from cache (if available)
    TypeOfItems items = (TypeOfItems)HttpContext.Current.Cache.Get(/*unique identity of you xml, such as url*/ url);
    if (items == null)
    {
        var xdoc = XDocument.Load(url);
        items = xdoc.Descendants("item").Select(item => new
            {
                Title = item.Element("title").Value,
                Description = item.Element("description").Value,
                Link = item.Element("link").Value,
                PubDate = item.Element("pubDate").Value, 
                MyImage = (string)item.Elements(dcM + "thumbnail")
               .Where(i => i.Attribute("width").Value == "144" && i.Attribute("height").Value == "81")
               .Select(i => i.Attribute("url").Value)
               .SingleOrDefault()
            })
            .ToList();
        HttpContext.Current.Cache.Add(/*unique identity of you xml, such as url*/url, /*data*/ items, null,
            DateTime.Now.AddMinutes(1) /*time of cache actual*/,
            System.Web.Caching.Cache.NoSlidingExpiration,
            System.Web.Caching.CacheItemPriority.Default, null);
    }
