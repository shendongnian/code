    using System.Data;
    using System.Data.SqlClient;
    
    			using (var con = new SqlConnection("your connection string")) {
    				con.Open();
    				using (var com = con.CreateCommand()) {
    					var var1 = "test";
    					var var2 = "test2";
    					com.CommandText = string.Format("INSERT INTO Table1(col1, col2) VALUES({0}, {1})", var1, var2);
    					com.CommandType = CommandType.Text;
    					com.ExecuteNonQuery();
    				}
    				con.Close();
    			}
