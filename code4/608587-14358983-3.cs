    using (var con = new SqlConnection(connectionString))
    {
       string sql = @"SELECT * FROM locGSP; 
                      SELECT * FROM locCountry; 
                      SELECT * FROM locMarketUnit";
       using(var da = new SqlDataAdapter(sql, con))
       {
           // demonstrate the issue here:
           DataSet dsWrong = new DataSet();
           da.Fill(dsWrong); // now all tables are in this format: Table,Table1,Table2
           
           // following will map the correct names to the tables
           DataSet dsCorrect = new DataSet();
           da.TableMappings.Add("Table", "locGSP");
           da.TableMappings.Add("Table1", "locCountry");
           da.TableMappings.Add("Table2", "locMarketUnit");
           da.Fill(dsCorrect); // now we have the correct table-names: locGSP,locCountry,locMarketUnit
       }
    }
