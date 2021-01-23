     [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string[] GetPatientFirstName(string prefix)
    {
        List<string> customers = new List<string>();
        using (SqlConnection conn = new SqlConnection())
        {
            string connectionstring = CCMMUtility.GetCacheForWholeApplication();
            conn.ConnectionString = connectionstring;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select distinct top(10) PatientFirstname from tblMessage where  " +
                "PatientFirstname  like '%'+ @SearchText + '%' order by PatientFirstname";
                cmd.Parameters.AddWithValue("@SearchText", prefix);
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(string.Format("{0}", sdr["PatientFirstname"]));
                    }
                }
                conn.Close();
            }
            return customers.ToArray();
        }
    }
