    using System.Runtime.InteropServices;
    using Microsoft.Office.Interop.Excel;
        Excel.ApplicationClass _Excel;
        Excel.Workbook WB;
        Excel.Worksheet WS;
    try
        {
        _Excel = new Microsoft.Office.Interop.Excel.ApplicationClass();
        WB = _Excel.Workbooks.Open("C:\\Book1.xls",
            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            Type.Missing, Type.Missing);
            
            //do something
            WB.Visible = true;
        }
        catch (Exception ex)
        {
            WB.Close(false, Type.Missing, Type.Missing);
            throw;
        }
        finally
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(WB);
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(_Excel);
        }
