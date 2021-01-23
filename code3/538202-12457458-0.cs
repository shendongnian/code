    public Excel.Application TryGetExistingExcelApplication()
    {
        try
        {
            object o = Marshal.GetActiveObject("Excel.Application");
            return (Excel.Application)o;
        }
        catch (COMException)
        {
            // Probably there is no existing Excel instance running, return null
            return null;
        }
    }
