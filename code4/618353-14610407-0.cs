    public bool rebateslip(int ticketID)
    {
        SqlCommand myCommand  = new SqlCommand("SELECT ID FROM ticket WHERE ID = @ticketID", con);
        SqlDataAdapter sqlDa = new SqlDataAdapter(myCommand);
    
        myCommand.Parameters.AddWithValue("@ticketID", ticketID);
        var reader = myCommand.Execute();
        return reader.HasRows;    
    }
