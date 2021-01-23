    namespace WebService1
    {
     public class RaumklassenHelper
     {
        internal static string Raumklasse()
        {
            DataTable tbl = new DataTable();
            JavaScriptSerializer js = new JavaScriptSerializer();
            StringBuilder sb = new StringBuilder();
            
            using (SqlConnection con = new SqlConnection(@"Data Source=Localhost\SQLEXPRESS;Initial Catalog=BOOK-IT-V2;Integrated Security=true;"))
            using (SqlCommand cmd = new SqlCommand(@"SELECT BEZEICHNUNG FROM RAUMKLASSE", con))
            {
               
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                tbl.Load(rdr);
                rdr.Close();
                var linqResults = from DataRow row in tbl.AsEnumerable()
                                  select new { raumKlassenObject = row.Field<string>("BEZEICHNUNG") };
                js.Serialize(linqResults, sb);
                string returnJSON = sb.ToString();
                return returnJSON;
            }
        }
    }
    }
