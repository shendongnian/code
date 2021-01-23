    public ActionResult Thumbnail(int id)
    {
        var tempImageUpload = new TemporaryImageUpload();
        tempImageUpload = _service.GetImageData(id) ?? null;
        if (tempImageUpload == null)
        {
            return HttpNotFound();
        }
        
        using (var input = new MemoryStream(tempImageUpload.TempImageData))
        using (var output = new MemoryStream())
        {
            ResizeImage(input, output, 640, 1000);
            return File(output.ToArray(), "image/jpeg");
        }
    }
