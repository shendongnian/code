    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    using (var wc = new WebClient())
    {
        doc.LoadHtml(wc.DownloadString(TextBoxUrl.Text));
    }
