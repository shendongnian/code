    public string CleanWordStyle(string htmlPage)
    {
      HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
      doc.LoadHtml(htmlPage);
      return doc.DocumentNode.InnerText;
    }
