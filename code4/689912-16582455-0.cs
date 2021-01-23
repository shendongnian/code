    public string getdata(SqlCommand command)
    {
        // Using statement to be sure to dispose the connection
        using(SqlConnection conn = new SqlConnection(connectionString))
        {
           try
           {
                conn.Open();
                cmd.Connection = conn;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    return "true";
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                 string msg = "Select Error:";
                 msg += ex.Message;
                 return msg;
            }
      }
      return "false";
    }
