    using (var con = new SqlConnection(Settings.Default.ConnectionString))
    {
        var insertSql = "INSERT INTO Users (id, name, country) VALUES (@id, @name, @country);";
        using (var insertCommand = new SqlCommand(insertSql, con))
        {
            var col1Param = new SqlParameter("@id", id);
            var col2Param = new SqlParameter("@name", name);
            var col3Param = new SqlParameter("@country", country);
            insertCommand.Parameters.Add(col1Param);
            insertCommand.Parameters.Add(col2Param);
            insertCommand.Parameters.Add(col3Param);
            con.Open();
            insertCommand.ExecuteNonQuery();
        }
    }
