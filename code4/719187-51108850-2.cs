    StringBuilder sb = new StringBuilder();
    string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True";
    using (var conn = new SqlConnection(connectionstring))
    {
        conn.Open();
        var comm = new SqlCommand("SELECT * FROM Customers", conn);
        SqlDataAdapter adap = new SqlDataAdapter(comm);
    
        DataTable dt = new DataTable("Customer");
        adap.Fill(dt);
    
        using (var parser = new ChoJSONWriter(sb))
            parser.Write(dt);
    }
    
    Console.WriteLine(sb.ToString());
