    public class CustomImageHandler : IHttpHandler
    {
            public void ProcessRequest(HttpContext context)
            {
    			//Get file name from query string and check balance for that file extension... read the file into aStream
    			
    			context.Response.Clear();
    			context.Response.ContentType = "image/...";
    			context.Response.AddHeader("Content-Disposition", string.Format("attachment; filename=\"{0}\"", GetTheFileName()));
    			context.Response.BinaryWrite(aStream.ToArray());
    		}
    }
