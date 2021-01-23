    using System.Data.SqlClient;
    using System.Data;
    
    namespace SO
    {
        class Program
        {
            static void Main(string[] args)
            {
                System.Data.DataTable YourData = new DataTable("Parameters");
                DataColumn column;
                DataRow row;
      
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "Test1";
                YourData.Columns.Add(column);
    
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "a";
    
                YourData.Columns.Add(column);
    
                row = YourData.NewRow();
                row["Test1"] = "newValue1";
                row["a"] = "122342";
                YourData.Rows.Add(row);
    
                row = YourData.NewRow();
                row["Test1"] = "morenew";
                row["a"] = "343";
                YourData.Rows.Add(row);
                
                row = YourData.NewRow();
                row["Test1"] = "again";
                row["a"] = "434545";
                YourData.Rows.Add(row);
             
    
                SqlConnectionStringBuilder connString = new SqlConnectionStringBuilder();
                connString.DataSource = "127.0.0.1";
                connString.InitialCatalog = "SO";
                connString.IntegratedSecurity = true;
                
    
                using (SqlConnection conn = new SqlConnection())
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "usp_UpdateSomeTable";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter p = cmd.Parameters.AddWithValue("@Parameters", YourData);
                    p.SqlDbType = SqlDbType.Structured;
                    p.TypeName = "dbo.ParamsType";
    
                    cmd.Connection = conn;
    
                    conn.ConnectionString = connString.ConnectionString;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
