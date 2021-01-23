    // Download page
    System.Net.WebClient client = new System.Net.WebClient();
    client.Proxy = new System.Net.WebProxy("{proxy address and port}");
    string html = client.DownloadString("http://example.com");
    // Process result
    HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
    htmlDoc.LoadHtml(html);
