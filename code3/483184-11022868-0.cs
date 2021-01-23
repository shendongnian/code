    public String getString(String sql)
    {
        using (DataSet ds = new DataSet())
        {
            string connstring = String.Format("Server={0};Port={1}; User Id={2};Password={3};Database={4};", tbHost, tbPort, tbUser, tbPass, tbDataBaseName);
            using (NpgsqlConnection conn = new NpgsqlConnection(connstring))
            {
                using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn))
                {
                    da.Fill(ds);
                    // You did check count of tables
                    if (ds.Tables.Count > 0)
                    {
                       DataTable dt = ds.Tables[0];
                       // But forgot to check count of Rows
                       if (dt.Rows.Count > 0)
                       {
                          object o = dt.Rows[0][0];
                          //  And returned value for nulls
                          //  Check for null is here because I don't know
                          //  This Postgresql classes
                          if (o != DBNull.Value && o != null)
                          {
                             return o.ToString();
                          }
                      }
                  }
               }
            }
        }
        // Return default value
        return "0";
    }
