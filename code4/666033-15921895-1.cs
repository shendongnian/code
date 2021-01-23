    using (SqlConnection connection = new SqlConnection(DBConnection))
    {
        string name = "John";
        int score = 123;
        float Accuracy = 20.0f;
        using (SqlCommand command = new SqlCommand("INSERT INTO HighScoreTable(Name, Score, Accuracy) VALUES(@name, @score, @accuracy)", connection);
        {
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@score", score);
            command.Parameters.AddWithValue("@accuracy", accuracy);
            command.Connection.Open();
            command.ExecuteNonQuery();
        }
    }
