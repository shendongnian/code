    using (var con = new SqlConnection(connectionString))
    {
       string sql = @"SELECT * FROM locGSP; 
                      SELECT * FROM locCountry; 
                      SELECT * FROM locMarketUnit";
       using (var cmd = new SqlCommand(sql, con))
       {
           con.Open();
           using (var rdr = cmd.ExecuteReader())
           {
               // after the next line the DataSet will have the correct table-names
               ds.Load(rdr, LoadOption.OverwriteChanges, "locGSP", "locCountry", "locMarketUnit");
           }
       }
    }
