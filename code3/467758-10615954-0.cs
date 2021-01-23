    using Excel = Microsoft.Office.Interop.Excel;
    using System.Reflection;
    using System.Runtime.InteropServices;
    ...
    //create objects
    Excel.Application oXL;
    Excel._Workbook oWB;
    Excel._Worksheet oSheet;
    oXL         = new Excel.Application();
    oXL.Visible = false;
    oWB         = oXL.Workbooks.Open(template_file);
    oSheet      = (Excel._Worksheet)oWB.Worksheets[1];
    
    //set cell values
    oSheet.Cells[1, 1] = "my value here";
    
    //set formatting
    oSheet.get_Range("A1", "A15").Font.Bold         = true;
    oSheet.get_Range("A1", "A15").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
    oSheet.get_Range("A1", "A15").ColumnWidth       = 20;
    
    //close 
    oXL.ActiveWorkbook.Close();
    Marshal.ReleaseComObject(oWB);
    Marshal.ReleaseComObject(oSheet);
    Marshal.ReleaseComObject(oXL);
