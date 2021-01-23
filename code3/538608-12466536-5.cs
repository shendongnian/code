    var input =  Response.QueryString["EntityId"];
    var connectionString = "...";
    
    var queryString = "SELECT Name FROM TABLE WHERE COLUMN=@EntityId";
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
                Response.Write(String.Format("For Rick Your Name is here{0}", reader[0]));
            }
        }
    }
