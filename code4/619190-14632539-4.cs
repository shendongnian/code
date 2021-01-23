    public bool rebateslip(int ticketID)
    {
        using(SqlCommand myCommand = new SqlCommand("SELECT ID FROM ticket WHERE ID = @ticketID", con))
        {
            myCommand.Parameters.AddWithValue("@ticketID", ticketID);
            using(var reader = myCommand.ExecuteReader())
            {
                return reader.HasRows;
            }
        }
    }
