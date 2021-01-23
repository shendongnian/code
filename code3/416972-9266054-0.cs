    public ActionResult GetMyImage(string ImageID)
    {
        // Construct absolute image path
        var imagePath = "whatever";
    
        return base.File(imagePath, "image/jpg");
    }
