    using System.Runtime.InteropServices;
    using Excel = Microsoft.Office.Interop.Excel;
    
    namespace ExcelComments
    {
        class Program
        {
            static void Main()
            {
                var application = new Excel.Application();
                var workbook = application.Workbooks.Open(@"C:\Yada yada\workbook with comments.xlsx");
                Excel.Worksheet worksheet = workbook.Sheets[1];
    
                Excel.Range range = worksheet.Cells[1, 1];
    
                //Here is your comment as a string
                var myComment = range.Comment.Text();
    
                workbook.Close(false);
                application.Quit();
    
                Marshal.ReleaseComObject(application);
            }
        }
    }
