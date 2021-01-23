    Excel.Range AllRange = mySheet.UsedRange;
    Excel.Range filtered = AllRange.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeVisible, Type.Missing);
    long colstuff = filtered.Areas.Count;
    if (colstuff > 1)
    {
      mySheet.Rows.EntireRow[1].Hidden = true;
      filtered = mySheet.UsedRange.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeVisible, Type.Missing);
      filtered.EntireRow.Delete(Excel.XlDirection.xlUp);
      mySheet.Rows.EntireRow[1].Hidden = false;   
    }
 
