    string conString = "SERVER=localhost;" +"DATABASE=mydatabase;" 
            "UID=aUser;" +"PASSWORD=aPassword;";
        MySqlConnection conn = new MySqlConnection(conString);
        conn.Open();
        try {
            MySqlCommand command = new MySqlCommand("select max(pid) from table", conn);
            textBox1.Text = command.ExecuteScalar();
        }
        finally {
            conn.Close();
        }
