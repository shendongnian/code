    private static void MoveItems(MySqlConnection conn, List<string> moveList)
    {
        string query = string.Format("insert into old_records select * from testes where id IN({0});" + " delete from testes where id IN({0})", string.Join(",", moveList.ToArray()));
        var cmd = new MySqlCommand
        {
            Connection = conn,
            CommandText = query
        };
        cmd.ExecuteNonQuery();
    }
