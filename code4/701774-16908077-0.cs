    using (var content = new MultipartFormDataContent())
    {
        content.Add(CreateFileContent(imageStream, "image.jpg", "image/jpeg"));
        content.Add(CreateFileContent(signatureStream, "image.jpg.sig", "application/octet-stream"));
        var response = await httpClient.PostAsync(_profileImageUploadUri, content);
        response.EnsureSuccessStatusCode();
    }
    private StreamContent CreateFileContent(Stream stream, string fileName, string contentType)
    {
        var fileContent = new StreamContent(stream);
        fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data") 
        { 
            Name = "\"files\"", 
            FileName = "\"" + fileName + "\""
        }; // the extra quotes are key here
        fileContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);            
        return fileContent;
    }
    [HttpPost]
    public ActionResult UploadProfileImage(IList<HttpPostedFileBase> files)
    {
        if(files == null || files.Count != 2)
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        // more code
    }
