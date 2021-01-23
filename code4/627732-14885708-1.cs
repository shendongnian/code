    public HttpResponseMessage Get(int id)
    {
        Foo myFoo = LoadSomeFooById(id);
        HttpResponseMessage myHttpResponseMessage = this.Request.CreateResponse(HttpStatusCode.OK, myFoo)
 
        CacheControlHeaderValue cacheControlHeaderValue = new CacheControlHeaderValue(); 
        cacheControlHeaderValue.Public = true;    
        cacheControlHeaderValue.MaxAge = TimeSpan.FromMinutes(30);
        myHttpResponseMessage.Headers.CacheControl = cacheControlHeaderValue;
        return myHttpResponseMessage;
    }
