	private static async Task doThing(object i) {
		Console.WriteLine("in do thing {0}", (int)i);
		await Task.Delay(TimeSpan.FromSeconds(5));
		Console.WriteLine("out of do thing {0}", (int)i);
	}
	static void Main(string[] args) {
		CancellationTokenSource source = new CancellationTokenSource();
		var exclusivityBlock = new ActionBlock<Func<Task>>(f => f(), new ExecutionDataflowBlockOptions { CancellationToken = source.Token }};
		exclusivityBlock.Post(() => doThing(1));
		exclusivityBlock.Post(() => doThing(2));
		exclusivityBlock.Post(() => doThing(3));
		exclusivityBlock.Post(
			async () => {
				Console.WriteLine("in do thing {0}", 4);
				await Task.Delay(TimeSpan.FromSeconds(5));
				Console.WriteLine("out of do thing {0}", 4);
			});
		exclusivityBlock.Complete();
		exclusivityBlock.Completion.Wait();
		Console.WriteLine("Done");
		Console.ReadKey();
		return;
	}
