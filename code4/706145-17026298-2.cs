    using(var bcp = new SqlBulkCopy(connection))
    using(var objectReader = ObjectReader.Create(ReadTimeSeries(source)))
    {
        bcp.DestinationTableName = "SomeTable";
        bcp.WriteToServer(objectReader);
    }
