    DataTable outputTable = new DataTable(); // New data table.
    outputTable.Columns.Add("ID", typeof(int)); // Add all columns.
    outputTable.Columns.Add("RptDateFrom", typeof(DateTime));
    outputTable.Columns.Add("RptDateTo", typeof(DateTime));
    outputTable.Columns.Add("GenerationDate", typeof(DateTime));
    outputTable.Columns.Add("RowPrefix", typeof(String));
    outputTable.Columns.Add("Field1", typeof(String));
    outputTable.Columns.Add("Field2", typeof(String));
    outputTable.Columns.Add("Field3", typeof(String));
    foreach (RecordMapping recordMapping in recordMappings)
    {
      outputTable.Rows.Add(
        companyId, 
        rptDateFrom, 
        rptDateTo, 
        generationDate, 
        recordMapping.RowPrefix, 
        recordMapping.Field1, 
        recordMapping.Field2, 
        recordMapping.Field3)
    }
