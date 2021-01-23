    con = new MySqlConnection("server=localhost;database=Customers;uid=root;pwd=******");
    try {
        con.Open();
        cmd = new MySqlCommand("SELECT concat(name,'|',lastname) FROM customer WHERE ID_customer= ?Parname;", con);
        cmd.Parameters.Add("?Parname", MySqlDbType.Float).Value = customer_card; // Are you sure that the ID is float? That's the first time I see anything like that!
        var tokens = ((String)cmd.ExecuteScalar()).Split('|');
        var firstName = tokens[0];
        var lastName = tokens[1];
        Console.Writeln("First={0}, Last={1}", firstName, lastName);
    } finally {
        con.Close();
    }
