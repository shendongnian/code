    public void GarbageCollect_Major()
    {
        // Force GC of two generations - to get any recent unneeded objects up to their finalizers.
        GC.Collect(1, GCCollectionMode.Forced);
        GC.WaitForPendingFinalizers();
        GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
        // This may be dubious. But it seemed to maintain more responsive system.
        // (perhaps 5-20 ms) Because full GC stalls .Net, give time to threads (related to GUI?)
        System.Threading.Thread.Sleep(10);
    }
