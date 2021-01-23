     public void Dispose()
     {
        _app.Quit();
        Marshal.ReleaseComObject(_app);
        GC.Collect();
        GC.WaitForPendingFinalizers();
     }
