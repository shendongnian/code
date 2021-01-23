    string sql = @"UPDATE Members
                   SET Name = @Name, Surname = @Surname, EntryDate = @EntryDate
                   WHERE Id = @Id";
    using (var connection = new SqlConnection(...))
    {
        connection.Open();
        using (var command = new SqlCommand(sql, connection))
        {
            command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = member.Name;
            command.Parameters.Add("@Surname", SqlDbType.NVarChar).Value = member.Surname;
            command.Parameters.Add("@EntryDate", SqlDbType.DateTime).Value = member.EntryDate;
            command.Parameters.Add("@Id", SqlDbType.NVarChar).Value = member.Id;
            int rows = command.ExecuteNonQuery();
            // TODO: Work out what to do if rows isn't 1
        }
    }
