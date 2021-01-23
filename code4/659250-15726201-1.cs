    public HttpResponseMessage Get()
    {
        var path = @"C:\dev\Git\wishlist\src\Wishlist.Website\Data\phones.json";
        var result = Request.CreateResponse(HttpStatusCode.OK);
        var stream = new FileStream(path, FileMode.Open);
        result.Content = new StreamContent(stream);
        result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        return result;
    }
