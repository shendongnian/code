    SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=database;User ID=uid;Password=pass");
    conn.Open();
    
    // assuming a textbox with id txtUserId exists 
    string userId = txtUserId.Text;
    string sql = "SELECT name, password FROM users WHERE id=@userid";
    
    SqlCommand cmd = new SqlCommand();
    cmd.Connection = conn;
    cmd.CommandType = CommandType.Text;
    cmd.CommandText = sql;
    cmd.Parameters.AddWithValue("userid", userId);
    
    SqlDataReader dr = cmd.ExecuteReader(); //If insert cmd.ExecuteNonQuery();
