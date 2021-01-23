    // it's a private class, so public fields are okay
    private class RetryingMessage<T>
    {
        public T Data;
        public int RetriesRemaining;
        public readonly List<Exception> Exceptions = new List<Exception>();
    }
    public static IPropagatorBlock<TInput, TOutput>
        CreateRetryingBlock<TInput, TOutput>(
        Func<TInput, Task<TOutput>> transform, int numberOfRetries,
        TimeSpan retryDelay, Action<IEnumerable<Exception>> failureHandler)
    {
        var source = new TransformBlock<TInput, RetryingMessage<TInput>>(
            input => new RetryingMessage<TInput>
            { Data = input, RetriesRemaining = numberOfRetries });
        // TransformManyBlock, so that we can propagate zero results on failure
        TransformManyBlock<RetryingMessage<TInput>, TOutput> target = null;
        target = new TransformManyBlock<RetryingMessage<TInput>, TOutput>(
            async message =>
            {
                try
                {
                    return new[] { await transform(message.Data) };
                }
                catch (Exception ex)
                {
                    message.Exceptions.Add(ex);
                    if (message.RetriesRemaining == 0)
                    {
                        failureHandler(message.Exceptions);
                    }
                    else
                    {
                        message.RetriesRemaining--;
                        Task.Delay(retryDelay)
                            .ContinueWith(_ => target.Post(message));
                    }
                    return null;
                }
            });
        source.LinkTo(
            target, new DataflowLinkOptions { PropagateCompletion = true });
        return DataflowBlock.Encapsulate(source, target);
    }
