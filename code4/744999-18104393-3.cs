    static Task<int> Foo(IEnumerable<int> items, CancellationToken token)
    {
        var sum = 0;
        var tcs = new TaskCompletionSource<int>();
        var obs = items.ToObservable(ThreadPoolScheduler.Instance);
        token.Register(() => tcs.TrySetCanceled());
        obs.Subscribe(i => sum += i, tcs.SetException, () => tcs.TrySetResult(sum), token);
        return tcs.Task;
    }
