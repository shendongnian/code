    using Excel = Microsoft.Office.Interop.Excel;
    
    public List<String> getOpenWorkbooks()
    {
    	List<String> workbookNames = new List<String>();
    	Excel.Application eApp = (Excel.Application)Marshal.GetActiveObject("Excel.Application");
    	if (eApp != null)
    	{
    		foreach (Excel.Workbook wb in eApp.Workbooks)
    		{
    			workbookNames.Add(wb.FullName);
    		}
    		Marshal.ReleaseComObject(eApp);
    		GC.WaitForPendingFinalizers();
    		GC.Collect();
    	}
    	return workbookNames;
    }
