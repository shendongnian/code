    // SqlConnection connection = cmd.Connection;
    connection.Open();
    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
    {
        int player1Index = reader.GetOrdinal("Player1");
        int player2Index = reader.GetOrdinal("Player2");
        while (reader.Read())  // one loop iteration per record returned from SELECT
        {
            string player1 = cmd.GetString(player1Index);
            string player2 = cmd.GetString(player2Index);
            … // do something with player1, and player2
        }        
    }
