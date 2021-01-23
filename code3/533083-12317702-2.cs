    using System.Runtime.InteropServices;
    using Excel = Microsoft.Office.Interop.Excel;
    
    namespace RemoveDupes
    {
        class Program
        {
            static void Main()
            {
                var excel = new Excel.Application();
                var workbook = excel.Workbooks.Open(@"C:\Test\Test.xlsx");
                Excel.Worksheet worksheet = workbook.Sheets[1];
    
                var usedRange = worksheet.UsedRange;
    
                usedRange.RemoveDuplicates(1);
    
                workbook.Close(true);
    
                Marshal.ReleaseComObject(excel);
            }
        }
    }
