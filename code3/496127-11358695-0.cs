    public string CleanWordStyle(string htmlPage)
    {
      HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
      doc.LoadHtml(htmlPage);
      StringBuilder TextOnly = new StringBuilder();
      foreach (var node in doc.DocumentNode.ChildNodes)
      {
         TextOnly.Append(node.InnerText);
         TextOnly.Append(" ");
      }
      return TextOnly.ToString();
    }
