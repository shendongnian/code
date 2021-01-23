    string fileExt = System.IO.Path.GetExtension(imageUpload.FileName);
    if (string.Equals(fileExt, ".jpg", StringComparison.OrdinalIgnoreCase))
    {
        foreach (string fileKey in HttpContext.Current.Request.Files.Keys)
        {
            HttpPostedFile file = HttpContext.Current.Request.Files[fileKey];
            if (file.ContentLength <= 0) continue; //Skip unused file controls.
        
            try
            {
                 ImageJob i = new ImageJob(file, "~/eventimages/<guid>_<filename:A-Za-z0-9>.<ext>",
                     new ResizeSettings("width=60&height=60&format=jpg&crop=auto"));
                 i.Build();
        
                 ImageJob j = new ImageJob(file, "~/eventimages/<guid>_<filename:A-Za-z0-9>.<ext>",
                     new ResizeSettings("width=250&height=250&format=jpg&crop=auto"));
                 j.Build();
        
                 string sitePath = MapPath(@"~");
                 thumbImagePath = i.FinalPath.Replace(sitePath, "~\\");
                 mainImagePath = j.FinalPath.Replace(sitePath, "~\\");
             }
             catch
             {
      // Had to swallow the exception here: 
      // http://stackoverflow.com/questions/7533845/system-argumentexception-parameter-is-not-valid
             }
         }
      }
