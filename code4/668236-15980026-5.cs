    public string DisplayTopicNames()
    {
        string topicNames = "";
        // declare the connection string 
        string database = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|/Forum.accdb;Persist Security Info=True";
        
        // Initialise the connection 
        using (OleDbConnection myConn = new OleDbConnection(database))
        {
            myConn.Open();
            // Create a command object 
            OleDbCommand myCommand = new OleDbCommand("SELECT TopicName FROM Topics", myConn);
            // Execute the command 
            using (OleDbDataReader myDataReader = myCommand.ExecuteReader())
            {
                // Extract the results 
                while (myDataReader.Read())
                {
                    for (int i = 0; i < myDataReader.FieldCount; i++)
                    {
                        ddl.Items.Add(myDataReader.GetValue(i));
                    }
                }
            }
        }
        // not sure anything needs returned here anymore
        // but you'll have to evaluate that
        return "";
    }
