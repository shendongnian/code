	internal static class Program {
		private static async Task doThing(object i) {
			Console.WriteLine("in do thing {0}", (int)i);
			await Task.Delay(TimeSpan.FromSeconds(5));
			Console.WriteLine("out of do thing {0}", (int)i);
		}
		private static void Main(string[] args) {
			CancellationTokenSource source = new CancellationTokenSource();
			var exclusivityBlock = CreateTrackingBlock<Func<Task>>(
				f => f(), new ExecutionDataflowBlockOptions { CancellationToken = source.Token });
			var task1 = exclusivityBlock.PostWithCompletion(() => doThing(1));
			var task2 = exclusivityBlock.PostWithCompletion(() => doThing(2));
			var task3 = exclusivityBlock.PostWithCompletion(() => doThing(3));
			var task4 = exclusivityBlock.PostWithCompletion(
				async () => {
					Console.WriteLine("in do thing {0}", 4);
					await Task.Delay(TimeSpan.FromSeconds(5));
					Console.WriteLine("out of do thing {0}", 4);
				});
			Task.WaitAll(task1, task2, task3, task4);
			Console.WriteLine("Done");
			Console.ReadKey();
			return;
		}
		private static ActionBlock<Tuple<T, TaskCompletionSource<object>>> CreateTrackingBlock<T>(Func<T, Task> action, ExecutionDataflowBlockOptions options = null) {
			return new ActionBlock<Tuple<T, TaskCompletionSource<object>>>(
				async tuple => {
					try {
						await action(tuple.Item1);
						tuple.Item2.TrySetResult(null);
					} catch (Exception ex) {
						tuple.Item2.TrySetException(ex);
					}
				},
				options ?? new ExecutionDataflowBlockOptions());
		}
		internal static Task PostWithCompletion<T>(this ActionBlock<Tuple<T, TaskCompletionSource<object>>> block, T value) {
			var tcs = new TaskCompletionSource<object>();
			var tuple = Tuple.Create(value, tcs);
			block.Post(tuple);
			return tcs.Task;
		}
	}
