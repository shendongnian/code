    [...]
    using (var bulkCopy = new SqlBulkCopy(destinationConnection))
    {             
     bulkCopy.ColumnMappings.Add("name", "nameperson"); //THIS A MAPPING REPLACE IT WITH YOUR NEED
     bulkCopy.DestinationTableName = "profile2";
    [....]
