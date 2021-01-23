    // System.Web.Script.Services.RestHandler
    internal static void WriteExceptionJsonString(HttpContext context, Exception ex, int statusCode)
    {
        //snip code setting up response
	    context.Response.TrySkipIisCustomErrors = true;
	    using (StreamWriter streamWriter = new StreamWriter(context.Response.OutputStream, new UTF8Encoding(false)))
	    {
		    if (ex is TargetInvocationException)
		    {
			    ex = ex.InnerException;
		    }
		    if (context.IsCustomErrorEnabled)
		    {
			    streamWriter.Write(JavaScriptSerializer.SerializeInternal(RestHandler.BuildWebServiceError(AtlasWeb.WebService_Error, string.Empty, string.Empty)));
		    }
		    else
		    {
			    streamWriter.Write(JavaScriptSerializer.SerializeInternal(RestHandler.BuildWebServiceError(ex.Message, ex.StackTrace, ex.GetType().FullName)));
		    }
		    streamWriter.Flush();
	    }
    }
