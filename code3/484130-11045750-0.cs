    public static void GetExcelData(string _path)
        {
            Excel.Application xlApp = new Excel.ApplicationClass();
            Excel._Workbook xlWorkbook = xlApp.Workbooks.Open(_path);
            Excel._Worksheet xlWorksheet = (Excel.Worksheet)xlWorkbook.Sheets.get_Item(1);
            Excel.Range xlRange = xlWorksheet.UsedRange;
           
            string firstcell == (xlRange.Cells[1, 1] as Excel.Range).Value2.ToString();
           
            xlWorkbook.Close(true, Type.Missing, Type.Missing);
            xlApp.Quit();
           
        }
