    public static bool check_db_entry(string query)
    {
        using (var conn = new MySqlConnection(DbMethods.constr))
        {
            conn.Open();
            using (var cmd = new MySqlCommand(query, conn))
            {
                return (int)cmd.ExecuteScalar() == 1;
            }
        }
    }
