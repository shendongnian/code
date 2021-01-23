    string clientname = TextBox1.Text; 
    string sqlquery = "INSERT INTO [STATUS] (Client_Name) VALUES (@Client_Name)"; 
    SqlCommand command = new SqlCommand(sqlquery, connection); 
    command.Parameters.AddWithValue("@Client_Name", clientname); 
    command.ExecuteNonQuery(); 
