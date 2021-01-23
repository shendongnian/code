    HttpResponseMessage response = new HttpResponseMessage();
    response.StatusCode = HttpStatusCode.OK;
    response.Content = new StreamContent(result);
    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
    {
        FileName = "foo.txt"
    };
