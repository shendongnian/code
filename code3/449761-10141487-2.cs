            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlApp = new Excel.ApplicationClass();
            xlWorkBook = xlApp.Workbooks.Open(_filename, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlWorkSheet.Cells[1,1].Value2 = value;
            //Or can use this way
            int[] intArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Range rng = xlWorkSheet.get_Range("A1", "J1");
            rng.Value = intArray; 
            xlWorkBook.Close(false, misValue, misValue);
            xlApp.Quit();
