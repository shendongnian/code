    using (var sqlConnection = new SqlConnection(Config.ConnString)) {
        sqlConnection.Open();
        using (SqlCommand command = sqlConnection.CreateCommand()) {
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "[dbo].[PROC_UPSERT_SHARE]";
            command.UpdatedRowSource = UpdateRowSource.None;
            command.parameters.Add(new SqlParameter("@fullName", "dwfae"));
            command.parameters.Add(new SqlParameter("@name", "aze"));
            command.parameters.Add(new SqlParameter("@root", "aze"));
            command.parameters.Add(new SqlParameter("@creationDate", new DateTime(2000, 10, 10)));
            command.parameters.Add(new SqlParameter("@lastAccessDate", new DateTime(1999, 11, 11)));
            command.parameters.Add(new SqlParameter("@lastWriteDate", new DateTime(1990,12,12)));
            command.parameters.Add(new SqlParameter("@subShareCount", 20));
            command.parameters.Add(new SqlParameter("@serverId", "serverx"));
            object x = command.ExecuteScalar();
            Console.WriteLine(x);
        }
    }
