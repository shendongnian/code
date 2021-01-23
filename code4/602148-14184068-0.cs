    public void UpdateRecord(string SProcName)
    {
        using(Conn= new SqlConnection(connectionString))
        {
            //open the database
            Conn.Open();
            //initialise the command builder for this connection
            SqlCommand dataCommand = new SqlCommand(SProcName, Conn);
            //add the parameters to the command 
            //loop through each parameter
            for (int Counter = 0; Counter < SQLParams.Count; Counter += 1)
            {
                 //add it to the SqlCommand
                 dataCommand.Parameters.Add(SQLParams[Counter]);
            }
            dataCommand.CommandType = CommandType.StoredProcedure;
            dataCommand.ExecuteNonQuery();
        }
    }
