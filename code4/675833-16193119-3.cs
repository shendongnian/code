    protected override void OnClosing(CancelEventArgs e)
    {
        // connect to the database
        using (SqlConnection c = new SqlConnection("connection string"))
        {
            // log the user out
            var cmd = new SqlCommand("UPDATE Users SET status = 0 WHERE UserId = @UserId", c);
            cmd.Parameters.AddWithValue("@UserId", // get your user id from somewhere
            var rowsAffected = cmd.ExecuteNonQuery();
            // make sure the update worked
            if (rowsAffected == 0)
            {
                // do something here to make sure they get logged out
            }
        }
    }
