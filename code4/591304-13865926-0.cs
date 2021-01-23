    using System;
    using Excel = Microsoft.Office.Interop.Excel;
    namespace WindowsFormsApplication2
    {
        static class Program
        {
            static void Main()
            {
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook book = xlApp.Workbooks.Add(Excel.XlSheetType.xlWorksheet);
                Excel.Worksheet sheet = book.ActiveSheet;
                sheet.Name = "Booya";
                Excel.Range range = sheet.Cells[1, 1];
                range.Value = "This is some text";
                book.SaveAs(@"C:\blah.xlsx");
            }
        }
    }
