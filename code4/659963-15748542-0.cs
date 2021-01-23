    StringBuilder sb = new StringBuilder();
    sb.Append("INSERT INTO sometable VALUES(@text1,@text2)");
    
    SqlConnection conn = new SqlConnection(connStr);
    SqlCommand command = new SqlCommand(sb.ToString());
    command.CommandType = CommandType.Text;
    command.Parameters.AddWithValue("text1", text1.Text);
    command.Parameters.AddWithValue("text2", text2.Text);
    command.ExecuteNonQuery();
