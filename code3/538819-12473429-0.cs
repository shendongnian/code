    using (SqlConnection connection = new SqlConnection(connectionString))
    using (SqlCommand command = connection.CreateCommand())
    {
        command.CommandText = "INSERT INTO PersonalInfo (Id, Name, LastName, ContactNumber, Address, Gender, Date_Of_Birth) VALUES (@Id, @Name, @LastName, @LastName, @Address, @Gender, @DateOfBirth)";
    
        command.Parameters.AddWithValue("@Id", txtID.Text);
        ...
    
        connection.Open();
        command.ExecuteNonQuery();
    }
