    public void CreateTable(string tblName)
    {
        using (var con = new MySqlConnection(MySqlConnectionString))
        {
            using (var cmd = new MySqlCommand(String.Format("CREATE TABLE {0} (size int(5))",tblName), con)
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
