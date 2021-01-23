      foreach (HtmlElement td in this.webBrowser1.Document.GetElementsByTagName("td")) 
      {
             Debug.WriteLine(td.InnerText);
            if (td.InnerText.Equals("test"))
            {
                         td.RaiseEvent("onclick");
            }
      }
