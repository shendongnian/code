    oXL = new Microsoft.Office.Interop.Excel.Application();
    oXL.Visible = true;
    oXL.DisplayAlerts = false;
    
    string path = "D:\\LOG.xls";
    if (!File.Exists(path)) 
    {
        mWorkBook = oXL.Workbooks.Add;
    } 
    else
    {
    	mWorkBook = oXL.Workbooks.Open(path, 0, false, 5, "", "", false,    Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true,
    		false, 0, true, false, false);
    }
