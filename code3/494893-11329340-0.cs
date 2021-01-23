    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod]
        public int[] SalesNumbersMonths(int[] months)
        {
            // Could use LINQ instead but since I don't know which version
            // of the framework you are using I am providing the naive approach
            // here. Also the fact that you are using ASMX web services which are
            // a completely obsolete technology today makes me think that you probably
            // are using something pre .NET 3.0
            List<int> result = new List<int>();
            foreach (var month in months)
            {
                result.Add(SalesNumberMonth(month));
            }
            return result.ToArray();
        }
    
    
        [WebMethod]
        public int SalesNumberMonth(int i)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Sql"].ConnectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "SELECT COUNT(*) FROM sales_Ventes V INNER JOIN sys_AnneesFiscales A ON V.AnneeFiscale = A.Code INNER JOIN sys_Mois M ON V.Mois = M.Code WHERE M.Code=@Code AND Active = 'true'";  
                cmd.Parameters.AddWithValue("@Code", i);
                return (int)cmd.ExecuteScalar();
            }
        }
    }
