    public class CompressAttribute : System.Web.Mvc.ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                HttpRequestBase request = filterContext.HttpContext.Request;
    
                string acceptEncoding = request.Headers["Accept-Encoding"];
    
                if (string.IsNullOrEmpty(acceptEncoding)) return;
    
                acceptEncoding = acceptEncoding.ToUpperInvariant();
    
                HttpResponseBase response = filterContext.HttpContext.Response;
    
                if (acceptEncoding.Contains("GZIP") && response.Filter != null)
                {
                    response.AppendHeader("Content-encoding", "gzip");
                    response.Filter = new GZipStream(response.Filter, CompressionMode.Compress);
                }
                else if (acceptEncoding.Contains("DEFLATE") && response.Filter != null)
                {
                    response.AppendHeader("Content-encoding", "deflate");
                    response.Filter = new DeflateStream(response.Filter, CompressionMode.Compress);
                }
            }
        }
