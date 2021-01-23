    [OutputCache(Duration = 20, VaryByParam = "photoId")]
    public ActionResult GetImage(long photoId, long type)
    {
        byte[] img = System.IO.File.ReadAllBytes(Server.MapPath("~/Images/aspNetHome.png"));
        return File(img, "image/png");
    }
