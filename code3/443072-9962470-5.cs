    private void button1_Click(object sender, EventArgs e)
    {
        // Declare. Assign a value to avoid a compiler error.
        Excel.Application xlApp = null;
        Excel.Workbook xlWorkBook = null;
        Excel.Worksheet xlWorkSheet = null;
    
        try {
            // Initialize
            xlApp = new Excel.ApplicationClass();
            xlWorkBook = xlApp.Workbooks.Open(myBigFile, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", true, false, 0, true, 1, 0);
            // If the cast fails this like could "leak" a COM RCW
            // Since this "should never happen" I wouldn't worry about it.
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            ...
        } finally {
            // Release all COM RCWs.
            // The "releaseObject" will just "do nothing" if null is passed,
            // so no need to check to find out which need to be released.
            // The "finally" is run in all cases, even if there was an exception
            // in the "try". 
            // Note: passing "by ref" so afterwords "xlWorkSheet" will
            // evaluate to null. See "releaseObject".
            releaseObject(ref xlWorkSheet);
            releaseObject(ref xlWorkBook);
            // The Quit is done in the finally because we always
            // want to quit. It is no different than releasing RCWs.
            if (xlApp != null) {
                xlApp.Quit();
            }
            releaseObject(ref xlApp);    
        }
    }
