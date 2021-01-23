    foreach (var item in _stables)
    {                 
        var dropSql = string.Format("DROP TABLE [{0}];", item.Value);
        using(var oConnDropTables = new SqlConnection(connectionString))
        using (var cmd = new SqlCommand(dropSql, oConnDropTables))
        {
            oConnDropTables.Open();
            cmd.ExecuteNonQuery();
        }
    }
