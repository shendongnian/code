    private static SemaphoreSlim semPool = new SemaphoreSlim(3, 3);
    semPool.Wait(cts.Token);
    public static void CancelAllDownloads()
        {
            cts.Cancel();
            cts = new CancellationTokenSource();
        }
