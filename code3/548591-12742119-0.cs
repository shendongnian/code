    DataSet source = GetMySourceDataSet();
    DataSet destination = new DataSet();
    
    DataTable orders = source.Tables["SalesOrderHeader"];
    
    // Query the SalesOrderHeader table for orders placed  
    // after August 8, 2001.
    IEnumerable<DataRow> query =
        from order in orders.AsEnumerable()
        where order.Field<DateTime>("OrderDate") > new DateTime(2001, 8, 1)
        select order;
    
    // Create a table from the query.
    DataTable modifiedOrders = query.IsAny() ? query.CopyToDataTable<DataRow>() : new DataTable();
    destination.Tables.Add(modifiedOrders);
