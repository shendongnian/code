    using Excel = Microsoft.Office.Interop.Excel;
    foreach (Excel.Worksheet ws in doc.Worksheets)
    {
        Excel.Range targetRange = (Excel.Range)ws.UsedRange;
        targetRange.Copy(Type.Missing);
        targetRange.Paste(Excel.XlPasteType.xlPasteValues, 
            Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
    }
