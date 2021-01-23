    HtmlElement site = this.webBrowser.Document.GetElementById("myID");
    foreach (HtmlElement item in site.Children)
      {
         if (item.InnerText != "something")
            {
               item.InvokeMember("Click");
            }
               else if (item.InnerText == "something")
            {
               break;
            }
      }
