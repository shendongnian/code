        public static class ExcelReaderFunctions {
            public static void ExcelInsertOLE(string path) {
                Microsoft.Office.Interop.Excel.Application excel = new Application();
                excel.Workbooks.Add();            
                Microsoft.Office.Interop.Excel.Workbook workBook = excel.ActiveWorkbook;
                Microsoft.Office.Interop.Excel.Worksheet sheet = workBook.ActiveSheet;
                OLEObjects oleObjects =    (Microsoft.Office.Interop.Excel.OLEObjects)
                    sheet.OLEObjects(Type.Missing);            
                oleObjects.Add(
                    Type.Missing,   // ClassType
                    path,           // Filename
                    true,           // Link
                    false,          // DisplayAsIcon
                    Type.Missing,   // IconFileName
                    Type.Missing,   // IconIndex
                    Type.Missing,   // IconLabel
                    Type.Missing,   // Left
                    Type.Missing,   // Top
                    Type.Missing,   // Width
                    Type.Missing    // Height
                );
                excel.Visible = true;
                workBook.Close(true);
                excel.Quit();
            }
        }
