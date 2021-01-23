    string updateStmt = "UPDATE dbo.Members SET Name = @Name, Surname = @Surname, EntryDate = @EntryDate WHERE Id = @ID";
    sqlCommand = new SqlCommand(updateStmt, sqlConnection);
    
    sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar, 100).Value = name;
    sqlCommand.Parameters.Add("@Surname", SqlDbType.VarChar, 100).Value = surname;
    sqlCommand.Parameters.Add("@EntryDate", SqlDbType.DateTime).Value = entrydate;
    sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Value = member.Id;
    
    sqlConnection.Open();
    sqlCommand.ExecuteNonQuery();
    sqlConnection.Close();
