    string constring = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString;
    SqlConnection con = new SqlConnection(constring);
    DataSet ds = new DataSet();
    try
     {
       SqlDataAdapter dataAdapter = new SqlDataAdapter(query, con);
       SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
       con.Open();
       dataAdapter.Fill(ds, "table");
       return ds;
     }
     catch (Exception ex)
      {
      }
        finally
        {
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
        }
