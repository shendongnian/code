    string connString = "SERVER=;UID=;PASSWORD=;DATABASE=;";
    MySqlConnection connect = new MySqlConnection(connString);
    MySqlCommand myCommand = connect.CreateCommand();
    string input = textBox4.Text;
    myCommand.CommandText = "SELECT * FROM project WHERE Id = @input";
    myCommand.Parameters.Add("@input", SqlDbType.Int).Value = Convert.ToInt32(textBox4.Text);
    connect.Open();
    MySqlDataReader reader = myCommand.ExecuteReader();
    if (reader.Read())
       textBox1.Text = reader["Name"].ToString();
    connect.Close();
