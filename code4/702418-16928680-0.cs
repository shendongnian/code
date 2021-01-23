    using System.Web;
    namespace HandlerExample
    {
       public class MyHttpHandler : IHttpHandler
       {
          public void ProcessRequest(HttpContext context)
          {
            // Get the file from azure storage here and return it using context.Response
          }
          public bool IsReusable
          {
             get { return true; }
          }
       }
    }
