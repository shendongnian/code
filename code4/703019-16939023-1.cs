        public void EditMember(Member member)
        {
            string Name = member.Name;
            string Surname = member.Surname;
            string EntryDate = member.EntryDate.ToString("dd.MM.yyyy");
            string Status = member.Status;
            sqlConnection.Open();
            sqlCommand = new SqlCommand("UPDATE Members SET Name = @name, Surname = @surname, " + 
                             "EntryDate = @date " + 
                             "WHERE Id = @id", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@name", Name);
            sqlCommand.Parameters.AddWithValue("@surname", Surname);
            sqlCommand.Parameters.AddWithValue("@date", EntryDate);
            sqlCommand.Parameters.AddWithValue("@id", Status);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
