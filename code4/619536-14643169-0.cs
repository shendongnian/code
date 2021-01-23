    DataTable table = new DataTable();
    if(filteredRows.Any())
    {
        table = filteredRows.CopyToDataTable();
    }
