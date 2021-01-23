    using (SqlConnection cnn = new SqlConnection(cnnString))
    {
        cnn.Open();
        using (SqlCommand cmd = new SqlCommand("SELECT * FROM Game WHERE gameID = @gameID", cnn))
        {
            cmd.Parameters.AddWithValue("@gameID", game_id);
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                var player1 = rdr.GetString(1);
                var player2 = rdr.GetString(2);
            }
        }
    }
