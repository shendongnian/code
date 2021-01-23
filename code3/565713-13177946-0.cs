    public class JsonData : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var json = serializer.Serialize(GetData());
            context.Response.ContentType = "application/json";
            context.Response.Write(json);
        }
    }
