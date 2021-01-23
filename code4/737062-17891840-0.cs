     WebBrowser browser = sender as WebBrowser; //is sender WebBrowser?
     HtmlElementCollection imgCollection = browser.Document.GetElementsByTagName("img");
     WebClient webClient = new WebClient();
    
    int count = 0; //if available
    int maximumCount = imgCollection.Count;
    foreach (HtmlElement img in imgCollection){
          string url = img.GetAttribute("src");
          webClient.DownloadFile(url, url.Substring(url.LastIndexOf('/')));
    
          //just in case added a maximum counter
          count++;
          if(count >= maximumCount)
               break;
    }
