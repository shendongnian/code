    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlTypes;
    using System.Data.SqlClient;
    using Excel = Microsoft.Office.Interop.Excel;
    class Program
    {
    static void Main(string[] args) {
        Program myProgram = new Program();
        myProgram.RunExcelReporting(1);
    }
    Excel.Application excelApp = null;
    Excel.Workbook book = null;    
    void RunExcelReporting(int x) {   
        try {
            
            excelApp = new Excel.Application();
            excelApp.Visible = true;
            book = excelApp.Workbooks.Open(@"\\imsfileserve\experiment.xlsm");
            excelApp.Run("ADO");
            book.Close(false, Type.Missing, Type.Missing);
        }
        catch (Exception ex) {
            Console.WriteLine(ex.ToString());
        }
        finally {
            if (book != null) {
                releaseObject(book);
                book = null;
            }
            if (excelApp != null) {
                excelApp.Application.Quit();
                excelApp.Quit();
                excelApp = null;
            }
        }
    }
    void releaseObject(object obj)
    {
        try {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            obj = null;
        }
        catch (Exception ex) {
            Console.WriteLine(ex.ToString());
            obj = null;
        }
        finally {
            GC.Collect();
        }
    } 
    }
