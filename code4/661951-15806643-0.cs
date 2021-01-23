    using (MySqlConnection c = new MySqlConnection("connection string here"))
    {
        c.Open();
        // and now let's select some data
        MySqlCommand cmd = new MySqlCommand("SELECT * FROM SomeTable", c);
        MySqlDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            // do something with the fields here
        }
    }
