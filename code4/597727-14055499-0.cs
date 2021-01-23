    using(SqlConnection connection = new SqlConnection(<connstring>))
    {
    connection.Open();
    
    SqlCommand command = new SqlCommand();
    command.Connection = connection;
    
    command.CommandText = <query1>;
    using(SqlDataReader reader = command.ExecuteReader())
    {
    
    DataGrid1.DataSource = reader;
    DataGrid1.DataBind();
    }
    
    command.CommandText = <query2>;
    using(SqlDataReader reader = command.ExecuteReader())
    {
    
    DataGrid2.DataSource = reader;
    DataGrid2.DataBind();
    }
    }
