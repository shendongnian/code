    public class CsvResult : ActionResult
    {
        private CsvExport<LiveViewListe> data;
        public CsvResult (CsvExport<LiveViewListe> data)
        {
            this.data = data;
        }
    
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
    
            HttpResponseBase response = context.HttpContext.Response;
    
            response.ContentType = "text/csv";
            response.AddHeader("Content-Disposition", "attachment; filename=file.csv"));
    
            if (data!= null)
            {
                response.Write(data.Export());
            }
        }
    }
