    using System.IO
    string imagesPath = HttpContext.Current.Server.MapPath("~/Assets/Images");
    string path = null;
    foreach (var filePath in Directory.GetFiles(imagesPath, id + ".*"))
    {
        switch (Path.GetExtension(filePath))
        {
           case ".png":
           case ".jpg":
           case ".gif":
               path = filePath;
               break;
        }
    }
