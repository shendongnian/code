    using Excel = Microsoft.Office.Interop.Excel;        
       
    [DllImport("User32")]
    public static extern int GetClassName(
        int hWnd, StringBuilder lpClassName, int nMaxCount);
    
    
    // Callback passed to EnumChildWindows to find any window with the
    // registered classname "paneClassDC" - this is the class name of
    // PowerPoint's accessible document window.
    public bool EnumChildProc(int hwnd, ref int lParam)
    {
        StringBuilder windowClass = new StringBuilder(128);
        GetClassName(hwnd, windowClass, 128);
        s += windowClass.ToString() + "\n";
        if (windowClass.ToString() == "EXCEL7")
        {
            lParam = hwnd;
        }
        return true;
    }
    
    public delegate bool EnumChildCallback(int hwnd, ref int lParam);
    
    
    [DllImport("User32")]
    public static extern bool EnumChildWindows(
        int hWndParent, EnumChildCallback lpEnumFunc, ref int lParam);
    
    
    [DllImport("User32")]
    public static extern int FindWindowEx(
        int hwndParent, int hwndChildAfter, string lpszClass,
        int missing);
    
    
    // AccessibleObjectFromWindow gets the IDispatch pointer of an object
    // that supports IAccessible, which allows us to get to the native OM.
    [DllImport("Oleacc.dll")]
    private static extern int AccessibleObjectFromWindow(
        int hwnd, uint dwObjectID,
        byte[] riid,
        ref Excel.Window ptr);
    
    
    // Get the window handle for a running instance of PowerPoint.
    internal List<String> GetAccessibleObject()
    {
    
        List<String> workbookNames = new List<String>();
        try
        {
            // Walk the children of the desktop to find PowerPoint’s main
            // window.
            int hwnd = FindWindowEx(0, 0, "XLMAIN", 0);
            while(hwnd != 0)
            if (hwnd != 0)
            {
                // Walk the children of this window to see if any are
                // IAccessible.
                int hWndChild = 0;
                EnumChildCallback cb =
                    new EnumChildCallback(EnumChildProc);
                EnumChildWindows(hwnd, cb, ref hWndChild);
    
    
                if (hWndChild != 0)
                {
                    // OBJID_NATIVEOM gets us a pointer to the native 
                    // object model.
                    uint OBJID_NATIVEOM = 0xFFFFFFF0;
                    Guid IID_IDispatch =
                        new Guid("{00020400-0000-0000-C000-000000000046}");
                    Excel.Window ptr = null;
                    int hr = AccessibleObjectFromWindow(
                        hWndChild, OBJID_NATIVEOM,
                        IID_IDispatch.ToByteArray(), ref ptr);
                    if (hr >= 0)
                    {
                        Excel.Application eApp = ptr.Application;
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
                    }
    
                    hwnd = FindWindowEx(0, hwnd, "XLMAIN", 0);
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.ToString());
        }
        return workbookNames;
    }
