    static void DoSomethingOrThrowAfterTimeout(int millisecondsTimeout)
    {
        CancellationTokenSource cts = new CancellationTokenSource(millisecondsTimeout);
        CancellationToken ct = cts.Token;
        // do some work
        ct.ThrowIfCancellationRequested();
        // do more work
        ct.ThrowIfCancellationRequested();
        // repeat until done.
    }
