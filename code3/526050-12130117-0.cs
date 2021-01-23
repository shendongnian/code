    using (var wc = new WebClient())
    {
        HtmlDocument doc = new HtmlDocument();
    
        doc.LoadHtml(wc.DownloadString("http://www.manta.com/mb?search=U.S.+Cellular&refine_company_loctype=B"));                
    
        var divs = doc.DocumentNode.SelectNodes("//div[@class='clear']");
    
        if (!divs.Any())
            Response.Write("Not found or timeout protection mechanism");
    
        foreach (var item in divs)
        {
            HtmlNode link = item.Descendants("a").FirstOrDefault();
            Response.Write(link.GetAttributeValue("href", string.Empty));
        }
    }
