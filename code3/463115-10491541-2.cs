    public object Any(Request request)
    {
	    base.Response.StatusCode = 302;
        base.Response.AddHeader(HttpHeaders.Location, "");
        base.Response.EndRequest();
	    return null;
    }
