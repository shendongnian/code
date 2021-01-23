        var doc = new HtmlDocument();
        doc.Load(new StringReader(responseData));
        var nodes = doc.DocumentNode.SelectNodes("//div");
        foreach (HtmlNode link in nodes)
        {
            string title = link.InnerText.Trim();
            // etc.
        }
