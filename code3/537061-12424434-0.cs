    public void ProcessRequest(HttpContext context)
    {
		string name = context.Request.QueryString["name"];
		//query database by name to get image binary data
		Byte[] bytes = ...;
		context.Response.ContentType = "image/png";
	    context.Response.BinaryWrite(bytes);
    }
