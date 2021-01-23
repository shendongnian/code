            thisThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            InteropExcel.Application excelApp = null;
            InteropExcel.Workbooks wkbks = null;
            InteropExcel.Workbook wkbk = null;
            try
            {
                    excelApp = new InteropExcel.Application();
                    wkbks = excelApp.Workbooks;
                    wkbk = wkbks.Open(fileName);
    ...
    
            }
            catch (Exception ex)
            {
            }
    
            if (wkbk != null)
            {
                excelApp.DisplayAlerts = false;
                wkbk.Close(false);
                Marshal.FinalReleaseComObject(wkbk);
                wkbk = null;
            }
    
            if (wkbks != null)
            {
                wkbks.Close();
                Marshal.FinalReleaseComObject(wkbks);
                wkbks = null;
            }
    
            if (excelApp != null)
            {
                // Close Excel.
                excelApp.Quit();
                Marshal.FinalReleaseComObject(excelApp);
                excelApp = null;
            }
    
            // Change culture back from en-us to the original culture.
            thisThread.CurrentCulture = originalCulture;    
        }
