    public void ExecuteBatch(SqlConnection conn, Stream script)
    {
        foreach (string part in GetScriptParts(script))
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = part;
            cmd.ExecuteNonQuery();
        }
    }
