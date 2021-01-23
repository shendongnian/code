     [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string[] LastName(string prefix)
    {
        List<string> customers = new List<string>();
        using (SqlConnection conn = new SqlConnection())
        {
            string connectionstring = CCMMUtility.GetCacheForWholeApplication();
            conn.ConnectionString = connectionstring;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select distinct top(10) Lastname from tblusers where  " +
                "Lastname  like '%'+ @SearchText + '%' order by Lastname";
                cmd.Parameters.AddWithValue("@SearchText", prefix);
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(string.Format("{0}", sdr["Lastname"]));
                    }
                }
                conn.Close();
            }
            return customers.ToArray();
        }
    }
 
