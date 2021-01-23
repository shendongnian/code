    public FileContentResult GetImage(string name)
    {
        byte[] image = GetImageFromDb(name);
        return FileContentResult(image, "image/jpg");
    }
