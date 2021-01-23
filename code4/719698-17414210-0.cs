        Microsoft.Office.Interop.Excel.Application excel = new Application();
        Microsoft.Office.Interop.Excel.Workbook workBook =
            excel.Workbooks.Open(fileLocation);
        Microsoft.Office.Interop.Excel.Worksheet sheet = workBook.ActiveSheet;
        sheet.Cells[2, 2] = "Text";
        workBook.Close(true);
        excel.Quit();
