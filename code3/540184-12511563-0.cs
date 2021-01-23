    var path = Server.MapPath("...");
    var images = System.IO.Directory.GetFiles(path, "*.png");
    System.Collections.Generic.List<string> urls = new System.Collections.Generic.List<string>();
    foreach (var image in images)
    {
         urls.Add(string.Format("http://{0}/{1}", Request.Url.Authority, image));
    }
