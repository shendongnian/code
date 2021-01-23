    public HttpResponseMessage GetFile(string id)
    {
        if (String.IsNullOrEmpty(id))
            return Request.CreateResponse(HttpStatusCode.BadRequest);
    
        string fileName;
        string localFilePath;
        int fileSize;
    
        localFilePath = getFileFromID(id, out fileName, out fileSize);
           
        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
        response.Content = new StreamContent(new FileStream(localFilePath, FileMode.Open, FileAccess.Read));
        response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
        response.Content.Headers.ContentDisposition.FileName = fileName;
        response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
    
        return response;
    }
