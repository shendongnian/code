    static bool TestConnectionString(string connectionString)
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            try
            {
                conn.Open();
                return (conn.State == ConnectionState.Open);
            }
            catch
            {
                return false;
            }
        }
        return false;
    }
