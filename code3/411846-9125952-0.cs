    HtmlElementCollection collection = web.Document.GetElementsByTagName("img");
    
    foreach(object e in collection) {
      //do my stuff with iterations
      var element = e as HtmlElement;
      if (element == null)
           Debug.Print("Type of e: {0}", e.GetType);
      else
      {
      // ok
      }
    }
