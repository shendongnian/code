    var input =  Response.QueryString["EntityId"];
    var connectionString = "...";
    
    var queryString = "SELECT * FROM TABLE WHERE COLUMN=@EntityId";
    using (SqlConnection connection = new SqlConnection(
                   connectionString))
    {
        connection.Open();    
        using(var command = new SqlCommand(queryString, connection))
        {
            Command.Parameters.AddWithValue("@EntityId",input) 
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                Console.WriteLine(String.Format("{0}", reader[0]));
            }
        }
    }
