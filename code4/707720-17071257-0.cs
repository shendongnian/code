    if (Size <= 512)
    {
        string path = string.Format("~/images/profiles/ProfilePic-Id-{0}.{1}",
            UserID, System.IO.Path.GetExtension(Request.Files[0].FileName));
        Request.Files[0].SaveAs(Server.MapPath(path));
    }
