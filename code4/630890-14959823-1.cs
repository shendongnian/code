    foreach (var image in dbcontext.Images)
    {
        var filename = image.Filename;
        var lastModified = System.IO.File.GetLastWriteTime(filename);
        if (lastModified != image.LastModified) 
        {
            image.LastModified = lastModified;        
        }
    }
    dbcontext.SaveChanges();
