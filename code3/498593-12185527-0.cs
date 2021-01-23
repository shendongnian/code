    public class MyCsvDownload : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var companyId = int.Parse(context.Request.QueryString["CompanyID"]);
            string companyName;
            ItemList list;
            // TODO: Load company name and items from Company ID.
            string attachment = string.Format("attachment; filename={0}_OutPut.csv", companyName); 
            
            context.Response.AddHeader("content-disposition", attachment);
            context.Response.ContentType = "text/csv";
            context.Response.AddHeader("Pragma", "public");
            StringBuilder stringBuilder = new StringBuilder();
            
            HelperClass.WriteColumnName("Column1,Column2,Column3", stringBuilder);
            context.Response.Write(stringBuilder.ToString());
            context.Response.Write(Environment.NewLine);
            stringBuilder.Clear();
            foreach (Item i in list.Items)
            {
                HelperClass.AddData(i.TaxCodeValue.ToString(), stringBuilder);
                HelperClass.AddData(i.Description.ToString(), stringBuilder);
                HelperClass.AddData(i.Description.ToString(), stringBuilder);
                context.Response.Write(stringBuilder.ToString());
                context.Response.Write(Environment.NewLine);
                stringBuilder.Clear();
            }
            context.Response.Flush();
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
