    public class controlloader : IHttpHandler
        {
            //If annonymous id is turned on IRequireSessionState Interface may be needed to write session variabled such as user auth.
            // Generic handlers by default implementIReadOnlySessionState
            public void ProcessRequest (HttpContext context)
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write(RenderPartialToString("~/Control1.ascx")); ;
            }
    
            private string RenderPartialToString(string controlname)
            {
                Page page = new Page();
                Control control = page.LoadControl(controlname);
                page.Controls.Add(control);
    
                StringWriter writer = new StringWriter();
                HttpContext.Current.Server.Execute(page, writer, false);
    
                return writer.ToString();
            }
    
            public bool IsReusable
            {
                get
                {
                    return false;
                }
            }
        }
