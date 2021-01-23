    private Excel.Application GetCurrentVersionOfExcel()
    {
        Excel.Application xlApp;
        // Try to get the currently-running Excel application
        try
        {
            xlApp = (Excel.Application)Marshal.GetActiveObject("Excel.Application");
        }
        catch
        {
            // In case there isn't a version running or the current version hasn't registered itself with the Running Object Table
            xlApp = null;
        }
        return xlApp;
    }
