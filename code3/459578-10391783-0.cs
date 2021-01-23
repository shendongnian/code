    static void Main(string[] args)
    {
      HtmlDocument doc = new HtmlDocument();
      doc.Load("example.html ");
      foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table"))
      {
        foreach (HtmlNode row in table.SelectNodes("tr"))
        {
          foreach (HtmlNode cell in row.SelectNodes("th|td"))
          {
            Console.WriteLine("Cell value : " + cell.InnerText);
          }
        }
      }
    }
