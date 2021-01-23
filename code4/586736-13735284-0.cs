    var siteMapBody = 
    from page in DataContext.Pages
            select new XElement(XName.Get("url"),
                   new XElement(XName.Get("location"), page.Url),
                   new XElement(XName.Get("title"), page.Title),
                   new XElement(XName.Get("lastmodified"), page.LastModified));
    
    var siteMapDocument = new XDocument(siteMapBody);
    var siteMap = siteMapDocument.ToString();
