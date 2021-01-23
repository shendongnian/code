    try
    {
    	//This requires excel app (excel.exe*32) to be running means any excel sheet should be open. If excel not running then it will throw error.
    	excelApp = (Excel.Application)Marshal.GetActiveObject("Excel.Application");
    	excelApp.Visible = false;
    }
    catch
    {
    	//create new excel instance
    	excelApp = new Excel.Application(); 
    	excelApp.Visible = false;
    }
    
