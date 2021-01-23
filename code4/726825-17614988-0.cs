    using (var sqlConnection
            = new SqlConnection(connectionString))
    {
        sqlConnection.Open();
    
        IEnumerable products = sqlConnection
            .Query("Select * from Products where Id = @Id",
                            new {Id = 2});
    
        foreach (dynamic product in products)
        {        
            ObjectDumper.Write(string.Format("{0}-{1}", product.Id, product.ProductName));
        }
        sqlConnection.Close(); 
    }
