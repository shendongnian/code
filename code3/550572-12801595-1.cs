    if (nFieldName.Contains("Sub Device") == false)
    {
        nRng = oSheet.get_Range("A1", oMissing);
        var col = nRng.EntireColumn
        col.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftToRight, false);
        var cells = oSheet.Cells;
        var firstCell = cells[1,1];
        firstCell.Value = "Sub Device";
        Marshal.ReleaseComObject(nRng);
        Marshal.ReleaseComObject(col);
        Marshal.ReleaseComObject(cells);
        Marshal.ReleaseComObject(firstCell);
    }
