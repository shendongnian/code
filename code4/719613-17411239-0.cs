    private static IEnumerable<IDataRecord> GetDataImpl(string query)
    {
        using (var conn = new MySqlConnection(DbMethods.constr))
        using (var cmd = new MySqlCommand(query, conn))
        {
            conn.Open();
            using (var rdr = cmd.ExecuteReader())
            {
               yield return rdr;
            }
        }
    }
    public static bool check_db_entry(string query)
    {
        return GetDataImpl(query).Any();
    }
