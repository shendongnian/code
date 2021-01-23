    public DataSet GetDataSet(string paramValue)
    {
        sqlcomm.Connection = sqlConn;
        using (sqlConn)
        {
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {  
                    // This will be your input parameter and its value
                    sqlcomm.Parameters.AddWithValue("@ParameterName", paramValue);
                    
                    // You can retrieve values of `output` variables
                    var returnParam = new SqlParameter
                    {
                        ParameterName = "@Error",
                        Direction = ParameterDirection.Output,
                        Size = 1000
                    };
                    sqlcomm.Parameters.Add(returnParam);
                    // Name of stored procedure
                    sqlcomm.CommandText = "StoredProcedureName";
                    da.SelectCommand = sqlcomm;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
    
                    DataSet ds = new DataSet();
                    da.Fill(ds);                            
                }
            }
            catch (SQLException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        return new DataSet();
    }
