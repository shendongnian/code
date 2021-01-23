    SqlBulkCopy _bc = new SqlBulkCopy(curConnection);
    _bc.DestinationTableName = "TestSP";
    _bc.ColumnMappings.Add(new SqlBulkCopyColumnMapping("DataTableColumnName1", "SQLServerColumnName1");
    _bc.ColumnMappings.Add(new SqlBulkCopyColumnMapping("DataTableColumnName2", "SQLServerColumnName2");
    _bc.ColumnMappings.Add(new SqlBulkCopyColumnMapping("DataTableColumnName3", "SQLServerColumnName3");
    _bc.ColumnMappings.Add(new SqlBulkCopyColumnMapping("DataTableColumnName4", "SQLServerColumnName4");
    _bc.WriteToServer(DtSet.Tables[0]);
