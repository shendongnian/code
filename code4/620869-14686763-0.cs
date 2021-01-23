    public ActionResult GetPhoto()
    {
        string user = Session["UserName"] as string;
        byte[] photo = db
            .tblUsers
            .Where(p => p.UserName == user)
            .Select(img => img.Photo)
            .FirstOrDefault();
        return File(photo, "image/jpeg");
    }
