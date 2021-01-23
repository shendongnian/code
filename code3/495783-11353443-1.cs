    foreach (string line in header)
    {
        Object entireRow = GetRow(sheet, columnCount, rowOffset);
        entireRow.GetType().InvokeMember("MergeCells",
        BindingFlags.SetProperty, null, entireRow,
        new object[] { true });
        entireRow.GetType().InvokeMember("HorizontalAlignment",
        BindingFlags.SetProperty, null, entireRow, new object[] { 3 });
        Object tlCell = GetCell(sheet, 1, rowOffset);
        tlCell.GetType().InvokeMember("Value2", BindingFlags.SetProperty,
        null, tlCell, new object[] { "'" + line });
        Object font = tlCell.GetType().InvokeMember("Font",
        BindingFlags.GetProperty, null, tlCell, null);
        rowOffset++;
    }
    for (int col = 0; col < data.Columns.Count; col++)
    {
        Object test = GetCell(sheet, col + 1, rowOffset);
        //DataTable Headers
        {
            Object erow = test.GetType().InvokeMember("EntireRow",
            BindingFlags.GetProperty, null, test, null);
            Object font = erow.GetType().InvokeMember("Font",
            BindingFlags.GetProperty, null, erow, null);
            erow.GetType().InvokeMember("HorizontalAlignment",
            BindingFlags.SetProperty, null, erow, new object[] { 3 });
            font.GetType().InvokeMember("Bold", BindingFlags.SetProperty,
            null, font, new object[] { true });
            test.GetType().InvokeMember("Value2", BindingFlags.SetProperty,
            null, test, new object[] { data.Columns[col].ColumnName.ToString() });
        }
    }
