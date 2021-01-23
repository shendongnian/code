    var data = InventSomeData(1000000);
    using(var bcp = new SqlBulkCopy(connection))
    using(var reader = ObjectReader.Create(data))
    { // note that you can be more selective with the column map
        bcp.DestinationTableName = "CustomerSelections";
        bcp.WriteToServer(reader);
    }
