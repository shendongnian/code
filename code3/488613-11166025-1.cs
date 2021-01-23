    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    
    public static List<string> GetCompletionList(string prefixText, int count)
        {
    
    using (SqlConnection conn = new SqlConnection())
        {
           string connString =    ConfigurationManager.ConnectionStrings   ["Station"].ToString();
    
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select StationName from Stations where " +
                "StationName like @SearchStation + '%'";
                cmd.Parameters.AddWithValue("@SearchStation", prefixText);
                cmd.Connection = conn;
                conn.Open();
                List<string> stations= new List<string>();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(sdr["StationName"].ToString());
                    }
                }
                conn.Close();
                return stations;
            }
        }
