    const string @select = "SELECT studentlastname + ' ' " +
                                   "+ studentfirstname + ' ' " +
                                   "+ studentmiddleinitial as FullName " +
                                   "FROM STUD_DB WHERE emailaddress = @mail";
    
    
    using (var connection = new SqlConnection(constr))
    {
        using (var command = new SqlCommand(select, connection))
        {
            connection.Open();
            command.Parameters.Add("mail", email);
            return command.ExecuteScalar() as string;
        }
    }
