    var dt = new DataTable();
    
                    using (var cnn = new SqlConnection(ConnectionString ))
                    using (var cmd = new SqlCommand("MY_PROC_NAME", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
    
                        cnn.Open();
                        var sqlReader = cmd.ExecuteReader();
                        if (sqlReader.HasRows)
                            dt.Load(sqlReader);
    
                        cnn.Close();
                    }
                    result = dt.DataTableToList<My_Class>();
