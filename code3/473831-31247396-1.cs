    public bool checkEmptyTable(){
            try
            {
                MySql.Data.MySqlClient.MySqlCommand com = new MySql.Data.MySqlClient.MySqlCommand();
                conn = new MySql.Data.MySqlClient.MySqlConnection("YOUR CONNECTION");
                com.Connection = conn;
                com.CommandText = "SELECT COUNT(*) from data";
                int result = int.Parse(com.ExecuteScalar().ToString());
                return result == 0; // if result equals zero, then the table is empty
            }
            finally
            {
                conn.Close();
            }
       }
