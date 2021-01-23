    using (var client = new WebClient())
    {
        client.Headers[HttpRequestHeader.AcceptLanguage] = "es-ES";
        client.Headers[HttpRequestHeader.UserAgent] = "some user agent if you wish";
        string html = client.DownloadString("http://example.com");
        // feed the HTML to HTML Agility Pack
        var doc = new HtmlDocument();
        doc.LoadHtml(html);
        // now do the parsing
    }
