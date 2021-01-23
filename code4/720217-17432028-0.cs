        Microsoft.Office.Interop.Excel.Application excel = new Application();
        Microsoft.Office.Interop.Excel.Workbook workBook =
            excel.Workbooks.Open(fileLocation);
        Microsoft.Office.Interop.Excel.Worksheet sheet = workBook.ActiveSheet;
        Microsoft.Office.Interop.Excel.Range range = sheet.UsedRange;
        string address = range.get_Address();
        string[] cells = address.Split(new char[] {':'});
        string beginCell = cells[0].Replace("$", "");
        string endCell = cells[1].Replace("$", "");
        workBook.Close(true);
        excel.Quit();
