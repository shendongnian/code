    var srcPath = Server.MapPath("..//Images//Temp//" + btnfile.FileName);
    if (!File.Exists(srcPath)
    {
        throw new Exception(string.Format("Could not find source file at {0}", srcPath));
    }
    var srcImage = Image.FromFile(srcPath);
    var thumb = srcImage.GetThumbnailImage(100, 150, null, IntPtr.Zero);
    var destPath = Server.MapPath("..//Images//Category//" + catid + "//");
    if (!Directory.Exists(destPath))
    {
        Directory.CreateDirectory(destPath);
    }
    thumb.Save(Path.Combine(destPath, btnfile.FileName));
