    using System.Runtime.InteropServices;
    using Excel = Microsoft.Office.Interop.Excel;
    
    namespace MyProgram
    {
        class Program
        {
            private static Excel.Application _app = new Excel.Application();
    
            static void Main()
            {
                Excel.Workbook workbook = _app.Workbooks.Open(@"C:\test\Dupes.xlsx");
                Excel.Worksheet worksheet = workbook.Sheets[1];
    
                Excel.Range range = worksheet.UsedRange;
    
                range.AdvancedFilter(Excel.XlFilterAction.xlFilterInPlace, null, null, true);
    
                workbook.Close(true);
    
                Marshal.ReleaseComObject(_app);
            }
        }
    }
