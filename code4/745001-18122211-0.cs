    public static IEnumerable<T> ToCancellable<T>(this IEnumerable<T> @this, CancellationToken token)
    {
        var enumerator = @this.GetEnumerator();
        var state = new State();
        for (; ; )
        {
            token.ThrowIfCancellationRequested();
            var thread = new Thread(s => { ((State)s).Result = enumerator.MoveNext(); }) { IsBackground = true, Priority = ThreadPriority.Lowest };
            thread.Start(state);
                
            try
            {
                while (!thread.Join(10))
                    token.ThrowIfCancellationRequested();
            }
            catch (OperationCanceledException)
            {
                thread.Abort();
                throw;
            }
            if (!state.Result)
                yield break;
            yield return enumerator.Current;
        }
    }
