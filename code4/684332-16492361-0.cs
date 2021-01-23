    <%@ WebHandler Language="C#" Class="NodeHandler" %>
    
    using System;
    using System.Web;
    public class NodeHandler : IHttpHandler {
        
        public void ProcessRequest (HttpContext context) {
            //Handle fingerprint stuff!!!
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }
     
        public bool IsReusable {
            get {
                return false;
            }
        }
    
    }
