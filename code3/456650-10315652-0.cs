      public class GetXml : IHttpHandler
      {    
        public void ProcessRequest(HttpContext context)
        {
          context.Response.ContentType = "text/xml";
          string xml = File.ReadAllText(context.Server.MapPath("~/App_Data/sample.xml"));
          context.Response.Write(xml);
          context.Response.End();    
        }
    
        public bool IsReusable
        {
          get
          {
            return false;
          }
        }
      }
