    public class MyHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            var objToSerialize = ...
            SerializerClass.MyDataContractJsonSerializer(
                objToSerialize, 
                objToSerialize.GetType(), 
                context.Response.OutputStream
            );
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
