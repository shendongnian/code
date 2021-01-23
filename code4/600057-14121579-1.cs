    using(var oConnDropTables = new SqlConnection(connectionString))
    {
        oConnDropTables.Open();
        foreach (var item in _stables)
        {                 
            var dropSql = string.Format("DROP TABLE [{0}];", item.Value);
            using (var cmd = new SqlCommand(dropSql, oConnDropTables))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
