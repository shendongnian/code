    const string query = @"update {0} set active= 'N' where id=@id;";
    public string GetCommandText(string table)
    {
        return string.Format(query, table);
    }
    public IEnumerable<string> GetTables()
    {
        yield return "table0";
        yield return "table1";
        yield return "table2";
        yield return "table4";
    }
    using (SqlCommand cmd = conn.CreateCommand())
    {
        cmd.Parameters.Add(new SqlParameter("@id", id));
        cmd.CommandText = GetTables().Select(GetCommandText).Aggregate((s, s1) => s + s1);
        
        conn.Open();
        cmd.ExecuteNonQuery();
    }
