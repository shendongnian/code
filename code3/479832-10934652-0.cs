    var name = txtName.Text;
    var birthdate = dpSBirthDate.SelectedDate;
    
    using (var connection = new SqlConnection(@"Server=MyMachineName\SQLEXPRESS;Database=MyDataBase;Integrated Security=SSPI")
    using (var command = connection.CreateCommand())
    {
        command.CommandText = "INSERT INTO courses " +
                              "(name, birthdate) VALUES " +
                              "(@name, @birthdate)";
    
        if (name == null)
            throw new Exception("Name cannot be null.");
        if (!birthdate.HasValue)
            throw new Exception("Birthdate must contain a value.");
        command.Parameters.AddWithValue("@name", name);
        command.Parameters.AddWithValue("@birthdate", birthdate.Value);
        connection.Open();
        command.ExecuteNonQuery();
    }
