        public static RunGC(GCParameters param = null)
        {
            lock (GCLock)
            {
                var theParams = param ?? GCParams;
                var sw = Stopwatch.StartNew();
                var timestamp = DateTime.Now;
                long memBefore = GC.GetTotalMemory(false);
                GC.Collect(theParams.Generation, theParams.Mode, theParams.Blocking, theParams.Compacting);
                GC.WaitForPendingFinalizers();
                //GC.Collect(); // may need to collect dead objects created by the finalizers
                var elapsed = sw.ElapsedMilliseconds;
                long memAfter = GC.GetTotalMemory(true);
                Log.Info($"GC starts with {memBefore} bytes, ends with {memAfter} bytes, GC time {elapsed} (ms)");
            }
        }
        // https://msdn.microsoft.com/en-us/library/system.runtime.gcsettings.largeobjectheapcompactionmode.aspx
        public static RunCompactingGC()
        {
            lock (CompactingGCLock)
            {
                var sw = Stopwatch.StartNew();
                var timestamp = DateTime.Now;
                long memBefore = GC.GetTotalMemory(false);
                GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
                GC.Collect();
                var elapsed = sw.ElapsedMilliseconds;
                long memAfter = GC.GetTotalMemory(true);
                Log.Info($"Compacting GC starts with {memBefore} bytes, ends with {memAfter} bytes, GC time {elapsed} (ms)");
            }
        }
