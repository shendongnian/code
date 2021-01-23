    using (var connection = new MySqlConnection("your connection string"))
    {
        connection.Open();
        // first we'll build our query string. Something like this :
        // INSERT INTO myTable VALUES (NULL, @number0, @text0), (NULL, @number1, @text1)...; 
        StringBuilder queryBuilder = new StringBuilder("INSERT INTO myTable VALUES ");
        for (int i = 0; i < 10; i++)
        {
            queryBuilder.AppendFormat("(NULL,@number{0},@text{0}),", i);
            //once we're done looping we remove the last ',' and replace it with a ';'
            if (i == 9)
            {
                queryBuilder.Replace(',', ';', queryBuilder.Length - 1, 1);
            }
        }
        
        MySqlCommand command = new MySqlCommand(queryBuilder.ToString(), connection);
        //assign each parameter its value
        for (int i = 0; i < 10; i++)
        {
            command.Parameters.AddWithValue("@number" + i, i);
            command.Parameters.AddWithValue("@text" + i, "textValue");
        }
        
        command.ExecuteNonQuery();
    }
