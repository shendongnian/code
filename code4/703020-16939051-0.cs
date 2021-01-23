    string sql = @"UPDATE Members SET (Name, Surname, EntryDate) 
                   VALUES (@Name, @Surname, @EntryDate)
                   WHERE Id = @Id";
    using (var connection = new SqlConnection(...))
    {
        connection.Open();
        using (var command = new SqlCommand(sql, connection))
        {
            command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
            command.Parameters.Add("@Surname", SqlDbType.NVarChar).Value = Surname;
            command.Parameters.Add("@EntryDate", SqlDbType.DateTime).Value = EntryDate;
            command.Parameters.Add("@Id", SqlDbType.NVarChar).Value = member.Id;
            int rows = command.ExecuteNonQuery();
            // TODO: Work out what to do if rows isn't 1
        }
    }
