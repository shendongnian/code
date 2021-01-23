    public ActionResult EnlargeShowcaseImage(string id)
    {
        var imageData = GetImage(id);
        if (imageData != null)
        {
            // TODO: adjust the MIME Type of the images
            return File(imageData, "image/png");
        }
    
        return new HttpNotFoundResult();
    }
