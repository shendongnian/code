    public async Task<IHttpActionResult> MyMethod(... myParameters ...)
    {
        ...
        var cookie = new CookieHeaderValue("myCookie", "myValue");
        ...
        
        var resp = new HttpResponseMessage();
        resp.StatusCode = HttpStatusCode.OK;
        resp.Headers.AddCookies(new[] { cookie });
        return ResponseMessage(resp);
    }
