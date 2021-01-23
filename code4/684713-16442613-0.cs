    private void LoadDataGrid(DataGrid dataGrid, DateTime date, string connectionString) 
    {
        using (var conn = new SqlConnection(connectionString)) 
        {
            using (SqlCommand cmd = conn.CreateCommand()) 
            {
                cmd.Parameters.Add(new SqlParameter {
                    ParameterName = "@Date",
                    SqlDbType = SqlDbType.DateTime,
                    Value = date
                });
                cmd.CommandText = "SELECT [Name], " +
                                  "       COUNT([Name]) AS Count " +
                                  "FROM   [DelegationTracker] " +
                                  "WHERE  [Date] = @Date " +
                                  "GROUP  BY [Name]";
    
                conn.Open();
                try 
                {
                    using (SqlDataReader reader = cmd.ExecuteReader()) 
                    {
                        dataGrid.DataSource = reader;
                        dataGrid.DataBind();
                    }
                }
                finally 
                {
                    conn.Close();
                }
            }
        }
    }
