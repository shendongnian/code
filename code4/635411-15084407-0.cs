    public Manager()
    {
        connection = new SqlConnection(@"Persist Security Info=False;User ID=user;Password=pass;Initial Catalog=Products;Server=(local)");
        if (connection.State != ConnectionState.Open) connection.Open();
    }
