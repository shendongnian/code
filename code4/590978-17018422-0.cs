    /// <summary>
    /// here is your server-side file generator
    /// </summary>
    public class export : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            // get some id from query string
            string someid = context.Request.QueryString["id"];
            try
            {
                ...
                context.Response.ContentType = "application/pdf";
                context.Response.HeaderEncoding = System.Text.Encoding.UTF8;
                context.Response.ContentEncoding = System.Text.Encoding.UTF8;
                context.Response.AppendHeader("Content-Disposition", "attachment; filename=filename.pdf");
                context.Response.Write(yourPDF); 
                /* or context.Response.WriteFile(...); */
            }
            catch (Exception ex)
            {
                /* exception handling */
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
