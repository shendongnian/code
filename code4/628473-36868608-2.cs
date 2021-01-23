    private void WriteArray(object[,] data)
    {
        Excel.Application app = (Excel.Application)ExcelDnaUtil.Application;
        Excel.Worksheet worksheet= (Excel.Worksheet)app.ActiveWorkbook.ActiveSheet;
        Excel.Range startCell = app.ActiveCell;
        Excel.Range endCell = (Excel.Range)worksheet.Cells[startCell.Row + data.GetLength(0) - 1, startCell.Column + data.GetLength(1) - 1];
        var writeRange = worksheet.Range[startCell, endCell];
        writeRange.Value2 = data;
    }
