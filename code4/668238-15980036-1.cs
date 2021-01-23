    public List<string> DisplayTopicNames()
    {
    	List<string> topics = new List<string>();
    
    	// Initialise the connection 
    	OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|/Forum.accdb;Persist Security Info=True");
    	OleDbCommand cmd = new OleDbCommand("SELECT TopicName FROM Topics");
    	using(conn)
    	using(cmd)
    	{
    		cmd.Connection.Open();
    		// Execute the command 
    		using(OleDbDataReader myDataReader = cmd.ExecuteReader())
    		{
    			// Extract the results 
    			while(myDataReader.Read())
    			{
				topics.Add(myDataReader.GetValue(0).ToString());
			}
		}
	}
	return topics;
}
