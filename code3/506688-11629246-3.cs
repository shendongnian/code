     public class getwindowsize : IHttpHandler {
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "application/json";
         string Height = context.Request.QueryString["Height"]; 
         string Width = context.Request.QueryString["Width"]; 
        }
