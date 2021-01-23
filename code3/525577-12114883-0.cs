    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    using (var wc = new WebClient())
    {
        doc.Load(wc.DownloadString(TextBoxUrl.Text));
    }
