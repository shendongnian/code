    string connectionString = @"Provider=Microsoft Office 12.0 Access Database Engine OLE DB Provider;" + @"Data source= C:\Users\nearod\Desktop\ImportDB.accdb";
    
    string queryString=  "SELECT * FROM [SQL Agent Unique ID Test Load]";
     try
            {
        using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand(queryString, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
        
                while (reader.Read())
                {
                    string companyCode = reader.GetValue(0).ToString();
                string agentId = reader.GetString(1);
                string firstName = reader.GetString(2);
                string lastName = reader.GetString(3);
                string nameSuffix = reader.GetString(4);
                string corporateName = reader.GetString(5);
                string entityType = reader.GetString(6);
                string obfSSN = reader.GetString(7);
                string obfFEIN = reader.GetString(8);
                string dummyIndicator = reader.GetString(9);
                // Insert code to process data.
                }
                reader.Close();
            }
    }
    catch (Exception ex)
       {
                MessageBox.Show("Failed to connect to data source");
       }
           
