    public Excel.Application excelApp = null;
    public Excel.Workbooks workbooks = null;
    ...
    try
    {
        excelApp = new Excel.Application();
        workbooks = excelApp.Workbooks;
        ...
    }
    finally
    {
        ...
        if (workbooks != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(workbooks);
        excelApp.Quit();
        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
    }
