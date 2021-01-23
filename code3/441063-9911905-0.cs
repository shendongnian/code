     using (var sqlConn = new SqlConnection("Server=localhost;Database=Test;Integrated Security=SSPI"))
                {
                    sqlConn.Open();
                    string sql = "Select * From table1; Select * From table2;";
                    using (var sqlCmd = new SqlCommand(sql, sqlConn))
                    {
                        var da = new SqlDataAdapter(sqlCmd);
                        var ds = new DataSet();
                        da.Fill(ds);
                        Console.WriteLine(ds.Tables.Count); // Will show 2 !
    
                    }
    
                }
