    foreach(HtmlNode table in doc.res.SelectNodes("//table"])
    {
      if(table != null)
      {
        var charName = table.InnerText.Substring(5).Trim();
      }
    }
