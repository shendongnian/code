    bulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(0, 1));
    bulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(1, 2));
    bulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(2, 3));
    bulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(3, 6)); //look here, index is different
    bulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(4, 8)); //and again
    bulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(5, 9));
