    string[] filePaths = Directory.GetFiles(Server.MapPath("~/Gallery/GalleryImage/" + v));
    foreach (string item in filePaths)
    {
        Response.Write(System.IO.Path.GetFileName(item));
    }
