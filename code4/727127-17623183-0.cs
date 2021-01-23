    volatile bool isCacheReady = false;
    Cache cache = null;
    System.Threading.Thread t1 = new System.Threading.Thread(delegate() {
        cache = HttpRuntime.Cache;
        isCacheReady = true;
    });
    t1.Start();
    // periodically check if cache is available yet (not here in this thread though):
    if( isCacheReady )
    {
        // do something with cache
    }
