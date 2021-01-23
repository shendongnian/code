    string path = null;
    foreach (var filePath in System.IO.Directory.GetFiles(HttpContext.Current.Server.MapPath(string.Format("~/Assets/Images/{0}.*", id))))
    {
        switch (System.IO.Path.GetExtension(filePath))
        {
           case ".png":
           case ".jpg":
           case ".gif":
               path = filePath;
               break;
        }
    }
