    public PartialViewResult Upload()
    {          
    
        string albumname = Request.Headers["albumname"];
        string baseDir = "~/Content/photoAlbums/" + Request.Headers["catid"] + "/" + Request.Headers["pageid"] + "/" (albumname != null ?  albumname + "/" : "");
    
        byte[] file = new byte[Request.ContentLength];
        Request.InputStream.Read(file, 0, Request.ContentLength);
    
        ImageJob b = new ImageJob(file, baseDir + "<guid>.<ext>", new ResizeSettings("maxwidth=1024&maxheight=768&format=jpg")); b.CreateParentDirectory = true; b.Build();
        ImageJob a = new ImageJob(file, baseDir + "<guid>_t.<ext>", new ResizeSettings("w=100&h=100&mode=crop&format=jpg")); a.CreateParentDirectory = true; a.Build();
    
        //Want both the have the same GUID? Pull it from the previous job.
        //string ext = PathUtils.GetExtension(b.FinalPath);
        //ImageJob a = new ImageJob(file, PathUtils.RemoveExtension(a.FinalPath) + "_t." + ext, new ResizeSettings("w=100&h=100&mode=crop&format=jpg")); a.CreateParentDirectory = true; a.Build();
    
    
        ViewBag.CatID = Request.Headers["catid"];
        ViewBag.PageID = Request.Headers["pageid"];
        ViewBag.FileName = Request.Headers["filename"];
    
        return PartialView("AlbumImage", PathUtils.GuessVirtualPath(a.FinalPath));
    }
