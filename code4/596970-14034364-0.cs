    public static int Insert(string cs, string table, string[] paramNames, object[] paramValues)
    {
        using (SqlConnection con = new SqlConnection(cs))
        {
            try
            {
                string strCommand = string.Format(
                    "INSERT INTO {0} VALUES ({1})", 
                    table, 
                    paramNames.Aggregate((a, b) => (a + ", " +b)));
                SqlCommand com = new SqlCommand(strCommand, con);
                for(x = 0; x < paramNames.Length; x++)
                    com.Parameters.AddWithValue(paramNames[x], paramValues[x]);
                con.Open();
                int result = com.ExecuteNonQuery();
                return result;
            }
            catch (SqlException ex)
            {
                HttpContext.Current.Response.Write(ex.Message);
                return 0;
            }
        }
    }
