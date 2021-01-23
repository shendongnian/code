    private Excel.Workbook GetWorkbook(string workbookName)
    {
        Excel.Window window = null;      // Excel window object from which application is grabbed
        Excel.Application app = null;    // Excel instance from which we get all the open workbooks
        Excel.Workbooks wbs = null;      // List of workbooks
        Excel.Workbook wb = null;        // Workbook to return
        EnumChildCallback cb;            // Callback routine for child window enumeration routine
        List<Process> procs = new List<Process>();           // List of processes
        // Get a full list of all processes that have a name of "excel"
        procs.AddRange(Process.GetProcessesByName("excel"));
        foreach (Process proc in procs)
        {
            // Make sure we have a valid handle for the window
            if ((int)proc.MainWindowHandle > 0)
            {
                // Get the handle of the child window in the current Excel process
                int childWindow = 0;
                cb = new EnumChildCallback(EnumChildProc);
                EnumChildWindows((int)proc.MainWindowHandle, cb, ref childWindow);
                // Make sure we got a valid handle
                if (childWindow > 0)
                {
                    // Get the address of the child window so that we can talk to it and
                    // get all the workbooks
                    const uint OBJID_NATIVEOM = 0xFFFFFFF0;
                    Guid IID_IDispatch =
                        new Guid("{00020400-0000-0000-C000-000000000046}");
                    int res = AccessibleObjectFromWindow(childWindow, OBJID_NATIVEOM,
                        IID_IDispatch.ToByteArray(), ref window);
                    if (res >= 0)
                    {
                        app = window.Application;
                        wbs = app.Workbooks;
                        // Loop through all the workbooks within the current Excel window
                        // to see if any match
                        for (int i = 1; i <= wbs.Count; i++)
                        {
                            wb = wbs[i];
                            if (wb.Name == workbookName)
                            {
                                break;
                            }
                            wb = null;
                        }
                    }
                }
            }
            // If we've already found our workbook then there's no point in continuing
            // through the remaining processes
            if (wb != null)
            {
                break;
            }
        }
        Release(wbs);
        Release(app);
        Release(window);
        return wb;
    }
