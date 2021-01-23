    //Get the first worksheet.
    Parameters = new Object[1];
    Parameters[0] = 1;
    excelSheet = excelSheets.GetType().InvokeMember("Item",
        BindingFlags.GetProperty, null, excelSheets, Parameters);
    //Set the Column Width within a large Range of cells.
    Parameters = new Object[2];
    Parameters[0] = "A1";
    Parameters[1] = "E55";
    excelRange = excelSheet.GetType().InvokeMember("Range",
        BindingFlags.GetProperty, null, excelSheet, Parameters);
    Parameters = new Object[1];
    Parameters[0] = 26;
    excelRange.GetType().InvokeMember("ColumnWidth",
    BindingFlags.SetProperty, null, excelRange, Parameters);
