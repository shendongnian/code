    string con = "server=localhost;user=root;pwd=1234;";
    
    using (MySqlConnection cn1 = new MySqlConnection(con))
    {
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = cn1;
        cn1.Open();
    
        cmd.CommandText = sql;
        MySqlDataAdapter da = new MySqlDataAdapter();
        ....
    }
