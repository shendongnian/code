    using System.Runtime.InteropServices;
    using Microsoft.Office.Interop.Excel;
    
    namespace ConsoleApplication19
    {
        class Program
        {
            static void Main(string[] args)
            {
                Application _excelApp = new Application();
                Workbook workbook = _excelApp.Workbooks.Open(@"C:\test\New Microsoft Excel Worksheet.xlsx");
    
                Worksheet sheet = (Worksheet)workbook.Sheets[1];
                Range excelRange = sheet.get_Range("A1");
    
                //If you comment the next line of code, you get '24/07/2012', if not you get '2012-07-24'
                excelRange.NumberFormat = "yyyy-mm-dd;@";
                excelRange.Value2 = "2012-07-13";
    
                workbook.Save();
                workbook.Close(false, @"C:\test\New Microsoft Excel Worksheet.xlsx", null);
                Marshal.ReleaseComObject(workbook);
            }
        }
    }
