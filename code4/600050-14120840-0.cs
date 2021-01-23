    string user = "1234";
    using (SqlCommand command = new SqlCommand("select * from [User] where UserId = @userid", cnn))
    {
        command.Parameters.AddWithValue("userid", user);
        using (SqlDataReader reader = myCommand.ExecuteReader())
        {
            // iterate your results here
        }
    }
