        var before = System.Diagnostics.Process.GetCurrentProcess().VirtualMemorySize64;
        if (before > 800000000)
        {
            dbcontextOut.SaveChanges();
            dbcontextOut.Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            dbcontextOut = dbcontextOutFunc();
            tableOut = Dynamic.InvokeGet(dbcontextOut, outputTableName);
        }
