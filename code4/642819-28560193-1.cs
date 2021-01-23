    HtmlElement site = this.webBrowser2.Document.GetElementById("myId");
    foreach (HtmlElement item in site.Children)
    { 
       if (item.InnerText.ToString() == "something")
       {
           item.InvokeMember("Click");
                 break;
       }
           else
       {
           item.InvokeMember("Click");
       }
    }
