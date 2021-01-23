    //Your code
    connection.Open();
    string sql = "INSERT INTO [CommentTab]([Name],[Comments]) Values(@username,@comments)";
    SqlCommand cmd = new SqlCommand(sql, connection);
    cmd.CommandType = CommandType.Text;
    cmd.Parameters.AddWithValue("@username", TextBox1.Text);
    cmd.Parameters.AddWithValue("@comments", TextBox2.Text);
    cmd.ExecuteNonQuery();
    cmd.Dispose();
    connection.Close();
    Response.Redirect("~/Default5.aspx");
