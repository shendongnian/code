    using System;
    using Microsoft.Office.Interop.Excel;
    
    namespace ConsoleApplication5
    {
    class Program
    {
    static void Main(string[] args)
    {
        RunVBATest();
    }
    
    public static void RunVBATest()
    {
        //System.Globalization.CultureInfo oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;
        //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        //object oMissing = System.Reflection.Missing.Value;
        Application oExcel = new Application();
        oExcel.Visible = true;
        Workbooks oBooks = oExcel.Workbooks;
        _Workbook oBook = null;
        oBook = oBooks.Open("C:\\temp\\Book1.xlsm");
    
        // Run the macro.
        RunMacro(oExcel, new Object[] { "TestMsg" });
    
        // Quit Excel and clean up.
        oBook.Saved = true;
        oBook.Close(false);
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oBook);
        oBook = null;
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oBooks);
        oBooks = null;
        oExcel.Quit();
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oExcel);
        oExcel = null;
        //System.Threading.Thread.CurrentThread.CurrentCulture = oldCI;
    }
    
    private static void RunMacro(object oApp, object[] oRunArgs)
    {
        oApp.GetType().InvokeMember("Run",
            System.Reflection.BindingFlags.Default |
            System.Reflection.BindingFlags.InvokeMethod,
            null, oApp, oRunArgs);
    }
    }
    }
