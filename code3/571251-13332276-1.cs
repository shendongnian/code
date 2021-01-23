    int amt;  
    using (var con = new SqlConnection(ConnectionString)) {
        var sql = "INSERT INTO dbo.Message(UserID, Message) VALUES(@UserID, @Message);";
        using (var cmd = new SqlCommand(sql, con)) {
            cmd.Parameters.AddWithValue("@UserID", userID); // assuming that it's apssed as argument
            cmd.Parameters.AddWithValue("@Message", txtMessage.Text); // f.e. "John's"
            con.Open();
            int inserted = cmd.ExecuteNonQuery();
        }
    }
