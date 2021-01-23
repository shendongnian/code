    public static string GetCurrentWorksheetUniqueIdentifier()
    {
        var workbook = ExcelApplication.ActiveWorkbook;
        var worksheet = ExcelApplication.ActiveSheet;
        try
        {
            return GetWorksheetUniqueIdentifier(workbook, worksheet);
        }
        finally
        {
            if (workbook != null &&
                Marshal.IsComObject(workbook))
                Marshal.ReleaseComObject(workbook);
            if (worksheet != null && 
                Marshal.IsComObject(worksheet))
                Marshal.ReleaseComObject(worksheet);
        }
    }
