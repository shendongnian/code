    string path = HttpContext.Current.Server.MapPath("~\\images");
    string filePattern = String.Format("{0}.*", CustomerName);
    string[] files = System.IO.Directory.GetFiles(path, filePattern);
    if (files.Length > 0)
    {
        //here you can check which file(s) was returned and the corresponding extension.
    }
