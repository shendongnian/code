    public class MvcApplication : System.Web.HttpApplication
    {    
        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
			//Activate request decompression
			string contentEncoding = Request.Headers["Content-Encoding"];
			if (contentEncoding != null && contentEncoding.Equals("gzip", StringComparison.CurrentCultureIgnoreCase))
			{
				Request.Filter = new GZipStream(Request.Filter, CompressionMode.Decompress, true);
			}
        }
    }
