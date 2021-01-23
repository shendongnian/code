    public class MyHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var response = context.Response;
            response.ContentType = "text/javascript";
            var message = "This is some super dynamic message. The UTC time now is: " + DateTime.UtcNow.ToLongTimeString();
            var js = string.Format("alert({0});", new JavaScriptSerializer().Serialize(message));
            response.Write(js);
        }
        public bool IsReusable 
        { 
            get { return true; } 
        }
    }
