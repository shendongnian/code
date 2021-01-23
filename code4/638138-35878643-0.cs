    public async Task AnAsyncMethodThatCompletes()
    {
        await SomeAsyncMethod();
        DoSomeMoreStuff();
		await Task.Factory.StartNew(() => { }); // <-- This line here, at the end
	}
    await AnAsyncMethodThatCompletes();
    Console.WriteLine("AnAsyncMethodThatCompletes() completed.")
