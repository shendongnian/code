    public class TestHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            StringWriter textWriter = new StringWriter();
            Html32TextWriter htmlTextWriter = new Html32TextWriter(textWriter);
            DataGrid dg = new DataGrid();
            dg.DataSource = GetData();
            //Get the html for the control
            dg.EnableViewState = false;
            dg.DataBind();
            dg.RenderControl(htmlTextWriter);
            //Write the HTML back to the browser.
            context.Response.Clear();
            //context.Response.AddHeader("Content-Disposition", string.Format("attachment;filename=test.csv"));
            //context.Response.ContentType = "text/csv";
            context.Response.AddHeader("Content-Disposition", string.Format("attachment;filename=abc.xls"));
            context.Response.ContentType = "application/vnd.ms-excel";
            context.Response.Write(textWriter.ToString());
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
