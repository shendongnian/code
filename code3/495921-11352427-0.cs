    // A method in your code-behind:
    public void Save(EmailMailingList list)
    {
        using(var connection = new SqlConnection("your connection string"))
        {
            var command = connection.CreateCommand();
            command.CommandText = "name of your stored procedure";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter( ... ));
            command.ExecuteNonQuery();
        }
    }
