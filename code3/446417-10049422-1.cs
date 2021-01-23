    namespace WebApplication1  
    {
      public partial class _Default : System.Web.UI.Page
      {
        public string xxx;
        protected void Page_Load(object sender, EventArgs e)
        {
            Stream stream = Request.InputStream;
            StreamReader streamReader = new StreamReader(stream);
            string test = streamReader.ReadToEnd();
            byte[] raw = Convert.FromBase64String(test);
            xxx = HttpUtility.UrlDecode(test); //FAILS
        }
      }
        public class MyHandler : IHttpHandler
        {
           public void ProcessRequest(HttpContext context)
           {
             var stream = context.Request.InputStream;
             byte[] buffer = new byte[stream.Length];
             stream.Read(buffer, 0, buffer.Length);
             string xml = Encoding.UTF8.GetString(buffer);
             ... do something with the XML
            // We only set the HTTP status code to 202 indicating to the
            // client that the request has been accepted for processing
            // but we leave an empty response body
            context.Response.StatusCode = 202;
           }
          public bool IsReusable
          {
            get
            {
              return false;
            }
          }
       }
    }
