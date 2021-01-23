    if (sinceLastGC.Minutes > Service.g_GCMinutes)
    {
         Service.g_LastGCTime = DateTime.Now;
         var sw = Stopwatch.StartNew();
         long memBefore = System.GC.GetTotalMemory(false);
         context.Response.Flush();
         context.ApplicationInstance.CompleteRequest();
         System.GC.Collect( Service.g_GCGeneration, Service.g_GCForced ? System.GCCollectionMode.Forced : System.GCCollectionMode.Optimized);
         System.GC.WaitForPendingFinalizers();
         long memAfter = System.GC.GetTotalMemory(true);
         var elapsed = sw.ElapsedMilliseconds;
         Log.Info(string.Format("GC starts with {0} bytes, ends with {1} bytes, GC time {2} (ms)", memBefore, memAfter, elapsed));
    }
