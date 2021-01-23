    <% @ WebHandler language="C#" class="AlarmHandler" %>
    using System.Web;
    public class AlarmHandler : IHttpHandler
    {
        // Constructor.
        public AlarmHandler() { }
        public void ProcessRequest(HttpContext context)
        {
            HttpRequest Request = context.Request;
            HttpResponse Response = context.Response;
            // Test code.
            Response.Write("<html>");
            Response.Write("<body>");
            Response.Write("<h1>Hello from a synchronous custom HTTP handler.</h1>");
            Response.Write("</body>");
            Response.Write("</html>");
        }
        public bool IsReusable
        {
            get { return false; }
        }
    }
