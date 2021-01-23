    [HttpGet]
    public FileResult GetImage(string id)
    {
        byte[] fileContents = ...; // load from database
        string contentType = "image/jpeg";
        return File(fileContents, contentType);
    }
