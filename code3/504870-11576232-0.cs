    var doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(yourHtml);
    if ( doc.DocumentNode != null )
    {
       var divs = doc.DocumentNode
                     .SelectNodes("//div")
                     .Where(e => e.Descendants().Any(e => e.Name == "h4"));
       // You now have all of the divs with an 'h4' inside of it.
       // The rest of the element structure, if constant needs to be examined to get
       // the rest of the content you're after.
    }
