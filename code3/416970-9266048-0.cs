    public ActionResult Image(string id)
    {
        var dir = Server.MapPath("/Images");
        var path = Path.Combine(dir, id + ".jpg");
        return base.File(path, "image/jpeg");
    }
    [HttpGet]
    public FileResult Show(int customerId, string imageName)
    {
        var path = string.Concat(ConfigData.ImagesDirectory, customerId, @"\", imageName);
        return new FileStreamResult(new FileStream(path, FileMode.Open), "image/jpeg");
    }
