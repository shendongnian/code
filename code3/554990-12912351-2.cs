    Excel.Application xlApp;
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlWorkSheet;
        object misValue = System.Reflection.Missing.Value;
        xlApp = new Excel.Application();
        xlWorkBook = xlApp.Workbooks.Open(ExcelFile, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue);
        xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
        
    Microsoft.Office.Interop.Excel.Range range = xlWorkSheet.Cells.SpecialCells(
                    Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
            for (int Loop = 1; Loop <= range.Row; Loop++)
            {
                Microsoft.Office.Interop.Excel.Range getRange = xlWorkSheet.get_Range("A" + Loop, "A" + Loop);
                Microsoft.Office.Interop.Excel.Range setRange = xlWorkSheet.get_Range("B" + Loop, "B" + Loop);
                setRange.Value = Convert.ToString(getRange.Value).Remove(8, 3);                
            }  
