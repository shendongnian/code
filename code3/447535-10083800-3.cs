    public class Upload : IHttpHandler, IRequiresSessionState
    {
    
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                HttpPostedFile file= context.Request.Files["Filedata"];
    
                int id = (Int32.Parse(context.Request["id"]));
                string foo = context.Request["foo"];
                file.SaveAs("C:\\" + id.ToString() + foo + file.FileName);
    
                context.Response.Write("1");
            }
            catch(Exception ex)
            {
                context.Response.Write("0");
            }
        }
    }
