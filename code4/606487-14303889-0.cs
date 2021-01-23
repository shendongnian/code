    ProcessTableData(DtSet.Tables["table1"]);
    ProcessTableData(DtSet.Tables["table2"]);    
    
    
    void ProcessTableData(DataTable dataTable)
    {
        if (dataTable == null)
            return;
    
        foreach (DataRow sourceRow in dataTable.Rows)
        {
        }
    }
