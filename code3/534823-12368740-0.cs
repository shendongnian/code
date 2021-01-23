    using System.Runtime.InteropServices;
    using Excel = Microsoft.Office.Interop.Excel;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                Excel.Application ap = new Excel.Application();
                Excel.Workbook wb = ap.Workbooks.Open(@"C:\whatever.xlsx");
                Excel.Worksheet ws = wb.ActiveSheet;
    
                ws.SaveAs(@"C:\somethingelse.xlsx");
    
                ap.Workbooks.Close();
                Marshal.ReleaseComObject(ap);
            }
        }
    }
