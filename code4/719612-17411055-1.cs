    public static bool check_db_entry(string query)
    {
        using (var conn = new MySqlConnection(DbMethods.constr))
        using (var cmd = conn.CreateCommand())
        {
            conn.Open();
            cmd.CommandText = query;
            return (int)cmd.ExecuteScalar() == 1;
        }
    }
