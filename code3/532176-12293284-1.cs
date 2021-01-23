    <%@ WebHandler Language="C#" Class="Downloader" %>
    
    using System;
    using System.Web;
    
    public class Downloader : IHttpHandler {
    
        public void ProcessRequest (HttpContext context) {
    
            // create a file response
            HttpResponse r = context.Response;
            r.ContentType = // set the appropriate content type;
 
            string file = context.Request.QueryString["file"];
    
            // *****
            // LOG THE REQUEST
            // *****
            // write out the file
            r.WriteFile(...);
        }
    
        public bool IsReusable {
            get {
                return false;
            }
        }
    }
