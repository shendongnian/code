	public void ProcessRequest(HttpContext context)
	{
		context.Response.ContentType = "text/plain";
		context.Response.Write("Received:\n");
		context.Response.Write(context.Request.Form["field1"]);
		context.Response.Write("\n");
		context.Response.Write(context.Request.Form["field2"]);
		context.Response.Write("\n");
	}
