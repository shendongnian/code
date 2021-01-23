    public void CreateTable(string tblName)
    {
        using (var con = new MySqlConnection(MySqlConnectionString))
        {
            using (var cmd = new MySqlCommand("CREATE TABLE @tblName (size int(5))", con))
            {
                cmd.Parameters.AddWithValue("@tblName", tblName);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
