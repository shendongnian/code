    public HttpResponseMessage Post()
    {
        HttpResponseMessage result = null;
        var httpRequest = HttpContext.Current.Request;
        if (httpRequest.Files.Count > 0)
        {
            foreach(string file in httpRequest.Files)
            {
                var postedFile = httpRequest.Files[file];
                var filePath = HttpContext.Current.Server.MapPath("~/" + postedFile.FileName);
                postedFile.SaveAs(filePath); 
            }
            result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
        }
        else
        {
            result = Request.CreateResponse(HttpStatusCode.BadRequest);
        }
        return result;
    }
