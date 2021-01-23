        private Excel.Application excelApp;
        private Excel.Workbook excelBook;
        private Excel.Worksheet excelSheet;
        object misValue = System.Reflection.Missing.Value;
        object oMissing = System.Reflection.Missing.Value;
        public ExcelModule()
        {
        }
        public void OpenWorksheet(string fileName, int sheetNum)
        {
            excelApp = new Excel.Application();
            excelBook = excelApp.Workbooks.Open(fileName,
                    0,
                    true,
                    5,
                    "",
                    "",
                    true,
                    Microsoft.Office.Interop.Excel.XlPlatform.xlWindows,
                    "\t",
                    false,
                    false,
                    0,
                    true,
                    1,
                    0);
            excelSheet = (Excel.Worksheet)excelBook.Worksheets.get_Item(sheetNum);
        }
        public string GetValue(string cellAddress)
        {
            if (excelSheet.get_Range(cellAddress, cellAddress).Value2 != null)
                return excelSheet.get_Range(cellAddress, cellAddress).Value2.ToString();
            else
                return "";
        }
        public int Close()
        {
            excelApp.Quit();
            return 0;
        }
        ~ExcelModule()
        {
            excelApp.Quit();
        }
    }
