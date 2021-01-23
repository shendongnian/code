    HtmlDocument doc = new HtmlDocument();
    doc.Load("file.htm");
    HtmlNode imgNode = doc.DocumentElement.selectSingleNode("/table/tr/td/img");
    
    //Just get Images only
    foreach (HtmlNode img in doc.DocumentElement.SelectNodes("//img"))
    {
      string imgSrc = img.Attributes["src"].Value;
    }
    
    //get td's and ignore img in it
    foreach (HtmlNode td in doc.DocumentElement.SelectNodes("//td"))
    {
      HtmlNode img = td.ChildNodes["img"];
      if(img == null)
      {
        string tdText = td.InnerText;
      }
    }
    //Get Images that have style attribute
    foreach (HtmlNode img in doc.DocumentElement.SelectNodes("//img[@style]"))
    {
      string style = img.Attributes["style"].Value.ToLower();
      style = style.Replace("background:url('", "");
      style = style.Replace("')", "");
     //now you have the image url from the background
    
    }
