    FileInfo file = new FileInfo(FILEPATH);
    
    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
    {
        FileName = file.Name
    };
    response.Content.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");
