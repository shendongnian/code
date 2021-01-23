    public static Task ForEachAsync<TIn>(
			IEnumerable<TIn> inputEnumerable,
			Func<TIn, Task> asyncProcessor,
			int? maxDegreeOfParallelism = null)
		{
			int maxAsyncThreadCount = maxDegreeOfParallelism ?? DefaultMaxDegreeOfParallelism;
			SemaphoreSlim throttler = new SemaphoreSlim(maxAsyncThreadCount, maxAsyncThreadCount);
			IEnumerable<Task> tasks = inputEnumerable.Select(async input =>
			{
				await throttler.WaitAsync().ConfigureAwait(false);
				try
				{
					await asyncProcessor(input).ConfigureAwait(false);
				}
				finally
				{
					throttler.Release();
				}
			});
			return Task.WhenAll(tasks);
		}
