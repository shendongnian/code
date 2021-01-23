    [HttpGet]
    public FileResult GetImage(string id)
    {
        byte[] fileContents = ...; // load from database or file system
        string contentType = "image/jpeg";
        return File(fileContents, contentType);
    }
