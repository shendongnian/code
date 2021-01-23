    XDocument wp = XDocument.Load("http://wordpress.org/news/feed/");
    XNamespace ns = XNamespace.Get("http://purl.org/rss/1.0/modules/content/");
    foreach (var content in wp.Descendants(ns + "encoded"))
    {
        Console.WriteLine(System.Net.WebUtility.HtmlDecode(content.Value)+"\n\n");
    }
