    public bool rebateslip(int ticketID)
    {
        using(SqlCommand myCommand = new SqlCommand("SELECT ID FROM ticket WHERE ID = @ticketID", con))
        {
            using(SqlDataAdapter sqlDa = new SqlDataAdapter(myCommand))
            {
                myCommand.Parameters.AddWithValue("@ticketID", ticketID);
                using(var reader = myCommand.ExecuteReader())
                {
                    return reader.HasRows;
                } 
            }
        }
    }
