    ...
    select new Link
    {
        Title = HttpUtility.HtmlDecode(item.Element(xName + "title").Value),
        Url = HttpUtility.HtmlDecode(item.Element(xName + "link").Value),
    }).ToList<Link>();
    ...
