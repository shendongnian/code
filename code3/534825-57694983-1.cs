    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using Excel = Microsoft.Office.Interop.Excel;
    using System.Runtime.InteropServices;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                Excel.Application objApp;
    
                objApp = (Excel.Application)Marshal.GetActiveObject("Excel.Application");
                /*Console.WriteLine(objApp.ActiveWorkbook.Name);
                Console.ReadKey(); */
    
                objApp.ActiveWorkbook.SaveAs(@"C:\temp\ExcelTest\Test.xlsx", Excel.XlFileFormat.xlWorkbookDefault);
            }
        }
    }
