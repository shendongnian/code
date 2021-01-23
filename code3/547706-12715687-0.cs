	string commandText = @"SELECT Id, ContactId
	FROM dbo.Subscriptions;
	
	SELECT Id, [Name]
	FROM dbo.Contacts;";
    List<Subscription> subscriptions = new List<Subscription>();
    List<Contact> contacts = new List<Contact>();
    using (SqlConnection dbConnection = new SqlConnection(@"Data Source=server;Database=database;Integrated Security=true;"))
    using (SqlCommand dbCommand = new SqlCommand(commandText, dbConnection))
    {
        dbCommand.CommandType = CommandType.Text;
        dbConnection.Open();
        SqlDataReader reader = dbCommand.ExecuteReader();
        while (reader.Read())
        {
            subscriptions.Add(
                new Subscription()
                {
                    Id = (int)reader["Id"],
                    ContactId = (int)reader["ContactId"]
                });
        }
	
        reader.NextResult();
        while (reader.Read())
        {
            contacts.Add(
                new Contact()
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"]
                });
        }
        dbConnection.Close();
    }
