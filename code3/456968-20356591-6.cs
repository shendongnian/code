    public HttpResponseMessage Post()
    {
        var httpRequest = HttpContext.Current.Request;
        if (httpRequest.Files.Count < 1)
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
        foreach(string file in httpRequest.Files)
        {
            var postedFile = httpRequest.Files[file];
            var filePath = HttpContext.Current.Server.MapPath("~/" + postedFile.FileName);
            postedFile.SaveAs(filePath);
            // NOTE: To store in memory use postedFile.InputStream
        }
        return Request.CreateResponse(HttpStatusCode.Created);
    }
