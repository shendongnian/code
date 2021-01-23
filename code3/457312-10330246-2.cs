    var dtCopyTo = new DataTable();
    foreach(var rowCopyFrom in dtCopyFrom.Rows)
    {
        var updatedDataRow = dtCopyTo.NewRow();
        updatedDataRow.ItemArray = rowCopyFrom.ItemArray;
        dtCopyTo.AddRow(updatedDataRow);
    }
                            
