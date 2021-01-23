    public class GetCsvFile : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/csv";
            context.Response.AddHeader("Content-Disposition", "attachment; filename=WBS.csv");
            context.Response.Write("WBSCode,Description,TerritoryCode,Amount\n");
        }
        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
