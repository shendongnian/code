    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
    SqlCommand cmd = new SqlCommand("UPDATE aspnet_membership SET email = @newEmail WHERE UserID = @userID");
    
    cmd.Connection = conn;
    cmd.CommandType = CommandType.Text;
    cmd.Parameters.AddWithValue("@email", Textbox2.Text);
    cmd.Parameters.AddWithValues("@UserId", YourUserId);
    
    conn.open();
    cmd.ExecuteNonQuery();
    conn.close();
