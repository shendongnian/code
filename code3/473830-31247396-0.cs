    public bool checkEmptyTable(){
     try
            {
                MySql.Data.MySqlClient.MySqlCommand com = new MySql.Data.MySqlClient.MySqlCommand();
                conn = new MySql.Data.MySqlClient.MySqlConnection("YOUR CONNECTION");
                com.Connection = conn;
                com.CommandText = "SELECT COUNT(*) from data";
                int result = int.Parse(com.ExecuteScalar().ToString());
                if (result == 0)
                    return true; //is empty
                else
                    return false;//is not empty
            
            }
            finally
            {
                conn.Close();
            }
}
