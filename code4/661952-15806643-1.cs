    using (MySqlConnection c = new MySqlConnection("connection string here"))
    {
        c.Open();
        // and now let's select some data
        MySqlCommand cmd = new MySqlCommand("UPDATE SomeTable SET Field1 = 'some value' WHERE some where clause", c);
        cmd.ExecuteNonQuery();
    }
