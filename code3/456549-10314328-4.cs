    using (var con = new SqlConnection(Settings.Default.ConnectionString))
    {
        con.Open();
        foreach (var record in records)
        {
            String insertSql = String.Format("INSERT INTO {0} ({1}) VALUES ({2});"
                , tableName
                , String.Join(",", record.Select(r => r.Key))
                , String.Join(",", record.Select(r => "@" + r.Key)));
            using (var insertCommand = new SqlCommand(insertSql, con))
            {
                foreach (var field in record)
                {
                    var param = new SqlParameter("@" + field.Key, field.Value);
                    insertCommand.Parameters.Add(param);
                }
                insertCommand.ExecuteNonQuery();
            }
        }
    }
