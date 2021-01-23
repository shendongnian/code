    using System.Data.SqlClient;
    
    
    namespace ConsoleApplication1
    {
        public class Lotto
        {
            public void InsertLottoNumbers(int[] lottonumbers)
            {
                var connectionstring = "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;";
    
                using (var con = new SqlConnection(connectionstring))  // Create connection with automatic disposal
                {
                    con.Open();
                    using (var tran = con.BeginTransaction())  // Open a transaction
                    {
                        // Create command with parameters  (DO NOT PUT VALUES IN LINE!!!!!)
                        string sql =
                            "insert into MyTable(val1,val2,val3,val4,val5,val6) values (@val1,@val2,@val3,@val4,@val5,@val6)";
                        var cmd = new SqlCommand(sql, con);
                        cmd.Parameters.AddWithValue("val1", lottonumbers[0]);
                        cmd.Parameters.AddWithValue("val2", lottonumbers[1]);
                        cmd.Parameters.AddWithValue("val3", lottonumbers[2]);
                        cmd.Parameters.AddWithValue("val4", lottonumbers[3]);
                        cmd.Parameters.AddWithValue("val5", lottonumbers[4]);
                        cmd.Parameters.AddWithValue("val6", lottonumbers[5]);
    
                        cmd.ExecuteNonQuery(); // Insert Record
    
                        tran.Commit();  // commit transaction
                    }
                }
            }
        }
    }
