    using (SqlConnection connection = new SqlConnection(DBConnection))
            {
                string name = "John";
                int score = 123;
                float Accuracy = 20.0f;
    
                SqlCommand command = new SqlCommand("INSERT INTO HighScoreTable(Name, Score, Accuracy) VALUES(@name,@score,@accuracy)", connection);
    
                   SqlParameter name= new SqlParameter("@name", name);
                    name.Value = name;
                    command.Parameters.Add(name);
                   .
                   . 
                   .
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
