    string connString = "Server=localhost;Database=request;Uid=root;Pwd=;";
    using (MySqlConnection mcon = new MySqlConnection(connString))
    using (MySqlCommand cmd = mcon.CreateCommand())
    {
        mcon.Open();
        cmd.CommandText = "SELECT * FROM requesttcw";
        using (MySqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                Console.WriteLine(reader["ID"]);
                Console.WriteLine(reader["ClanName"]);
                Console.WriteLine(reader["Date"]);
                Console.WriteLine(reader["Type"]);
                Console.WriteLine(reader["Rules"]);
            }
        }
    }
    using (MySqlConnection mcon = new MySqlConnection(connString))
    using (MySqlCommand cmd = mcon.CreateCommand())
    {
        mcon.Open();
        cmd.CommandText = "INSERT INTO requesttcw (ClanName, Date, Type, Rules) VALUES (@ClanName, @Date, @Type, @Rules)";
        cmd.Parameters.AddWithValue("@ClanName", textBox1.Text);
        // Warning if the Date column in your database is of type DateTime
        // you need to parse the value first, like this:
        // cmd.Parameters.AddWithValue("@Date", Date.Parse(textBox2.Text));
        cmd.Parameters.AddWithValue("@Date", textBox2.Text);
        cmd.Parameters.AddWithValue("@Type", textBox3.Text);
        cmd.Parameters.AddWithValue("@Rules", richTextBox1.Text);
        cmd.ExecuteNonQuery();
    }
