    Excel.Application xlApp;
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlWorkSheet;
        object misValue = System.Reflection.Missing.Value;
        xlApp = new Excel.Application();
        xlWorkBook = xlApp.Workbooks.Open(ExcelFile, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue);
        xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
        
    Microsoft.Office.Interop.Excel.Range range = xlWorkSheet.Cells.SpecialCells(
                    Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
            string value = string.Empty;
            for (int Loop = 1; Loop <= range.Row; Loop++)
            {
                value = Convert.ToString(xlWorkSheet.Range["A" + Loop, "A" + Loop].get_Value(misValue));
                xlWorkSheet.Range["B" + Loop, "B" + Loop].set_Value(misValue, value.Remove(8, 3));
            }  
