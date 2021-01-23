    using (SqlBulkCopy bcp= new SqlBulkCopy(yourConnectionString))
    {
        BulkCopy.DestinationTableName = "TargetTable";
        BulkCopy.WriteToServer(dataTable);
    }
