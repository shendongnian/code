    da.InsertCommand = new MySqlCommand("INSERT INTO niki (name, user_password) VALUES (?name, ?user_password)", con);
    da.InsertCommand.Parameters.Add("?name", MySqlDbType.VarChar).Value = textBox1.Text;
    da.InsertCommand.Parameters.Add("?user_password", MySqlDbType.VarChar).Value=textBox2.Text;
    
    enter code here
