    public static string ConnectionString {get;set;}
    public static bool InsertRecord(sql)
    {
        bool success = false;
        using (var con = new Connection(ConnectionString)){
            var command = new SqlCommand(sql,con);
            success = (command.ExecuteNonQuery() > 0);
        }
        return success;
    }
