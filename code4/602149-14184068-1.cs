    public void UpdateRecord(string SProcName, List<SqlParameters> prms)
    {
        using(Conn= new SqlConnection(connectionString))
        {
            //open the database
            Conn.Open();
            //initialise the command builder for this connection
            SqlCommand dataCommand = new SqlCommand(SProcName, Conn);
            //add the parameters to the SqlCommand
            dataCommand.Parameters.AddRange(prms.ToArray());
            dataCommand.CommandType = CommandType.StoredProcedure;
            dataCommand.ExecuteNonQuery();
        }
    }
