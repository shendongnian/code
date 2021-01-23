    using System.Reflection;
    using System.Runtime.InteropServices;
    using Excel = Microsoft.Office.Interop.Excel;
    // prepare Input
            Excel.Application xlApp = new Excel.Application();
            xlApp.DisplayAlerts = false;
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(fileNameIn);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;      //I copy everything
    // prepare Output
            Excel.Application oXL = new Excel.Application();
            oXL.DisplayAlerts = false;
            Excel.Workbook mWorkBook = oXL.Workbooks.Open(fileNameOut, 0, false, 5,
                                    "", "", false, Excel.XlPlatform.xlWindows,
                                    "", true, false, 0, true, false, false);
            Excel.Worksheet mWSheet1 = mWorkBook.Sheets[1];
    // make Copy&Paste in PC memory
            xlRange.Copy(Type.Missing);
            Excel.Range targetRange = mWSheet1.Cells[11, 1];   //initial cell for Paste
            mWSheet1.Paste(targetRange);
    // save Output
            mWorkBook.SaveAs(fileNameOut, Excel.XlFileFormat.xlWorkbookNormal, 
                                    Missing.Value, Missing.Value,
                                    Missing.Value, Missing.Value,  
                                    Excel.XlSaveAsAccessMode.xlExclusive,
                                    Missing.Value, Missing.Value,
                                    Missing.Value, Missing.Value, Missing.Value);
    // clean the waste !
            mWorkBook.Close(Missing.Value, Missing.Value, Missing.Value);
            mWSheet1 = null; mWorkBook = null; oXL.Quit();
            GC.WaitForPendingFinalizers(); GC.Collect(); GC.WaitForPendingFinalizers();
            GC.Collect(); GC.WaitForPendingFinalizers();
            Marshal.ReleaseComObject(xlRange); Marshal.ReleaseComObject(xlWorksheet);
            xlWorkbook.Close(); Marshal.ReleaseComObject(xlWorkbook);
            xlApp.Quit(); Marshal.ReleaseComObject(xlApp);
