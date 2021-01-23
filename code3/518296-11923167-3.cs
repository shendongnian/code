    public List<object[]> Select() {
        string query = "SELECT * FROM tableinfo";
    
        // Create a list to store the result
        var result = new List<object[]>();
    
        // Open connection
        if (this.OpenConnection()) {
            // Create Command
            var cmd = new MySqlCommand(query, connection);
            // Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();
            
            // Read the data and store them in the list
            while(dataReader.Read()) {
                object[] items = new object[dataReader.FieldCount];
                dataReader.GetValues(items);
                result.Add(items);
            }
    
            // Close Data Reader
            dataReader.Close();
    
            // Close Connection
            this.CloseConnection();
    
            // Return list to be displayed
            return list;
        } else {
            // This is a bad thing.
            throw new ApplicationException("Could not connect to database.");
        }
    }
