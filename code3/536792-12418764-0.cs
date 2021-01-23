    private List<string> retrieveImages()
    {
      List<string> imgList = new List<string>();
      HtmlDocument doc = new HtmlDocument();
      doc.Load("file.htm"); //or whatever HTML file you have
      HtmlNodeCollection imgs = doc.DocumentNode.SelectNodes("//img[@src]");
      if (imgs == null) return new List<string>();
      foreach (HtmlNode img in imgs)
      {
       if (img.Attributes["src"] == null)
          continue;
       HtmlAttribute src = img.Attributes["src"];
       
       imgList.Add(src.Value);
       //Do something with src.Value such as Get the image and save it locally
       // Image img = GetImage(src.Value)
       // img.Save(aLocalFilePath);
      }
    return imgList;
    }
    
    private Image GetImage(string url)
    {
        System.Net.WebRequest request = System.Net.WebRequest.Create(url);
    
        System.Net.WebResponse response = request.GetResponse();
        System.IO.Stream responseStream = response.GetResponseStream();
    
        Bitmap bmp = new Bitmap(responseStream);
    
        responseStream.Dispose();
    
        return bmp;
    }
