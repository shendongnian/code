    public string DisplayTopicNames()
    {
    	StringBuilder b = new StringBuilder();
        string topicNames = "";
    
        // Initialise the connection 
        OleDbConnection myConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|/Forum.accdb;Persist Security Info=True");
        OleDbCommand cmd = new SqlCommand("SELECT TopicName FROM Topics");
    	using(myConn)
    	using(cmd)
    	{
    		myConn.Open()
    		// Execute the command 
    		using(OleDbDataReader myDataReader = myCommand.ExecuteReader())
    		{
    		    // Extract the results 
    			while (myDataReader.Read())
    			{
    				for (int i = 0; i < myDataReader.FieldCount; i++)
    					b.Append(myDataReader.GetValue(i) + " ");
    				b.Append(";");
    			}
    		}
    	}
    
        //Because the topicNames are seperated by a semicolon, I would have to split it using the split()
    	topicNames = b.ToString();
        string[] splittedTopicNames = topicNames.Split(';');
    
        return Convert.ToString(splittedTopicNames);
    }
