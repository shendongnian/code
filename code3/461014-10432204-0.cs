    if(dr_art_line.Table.Columns.Contains("BarcodeIssueUnit"))
    {
        BarcodeIssueUnit = dr_art_line.Field<String>("BarcodeIssueUnit");
    }
    else
    {
        BarcodeIssueUnit = String.Empty;
    }
