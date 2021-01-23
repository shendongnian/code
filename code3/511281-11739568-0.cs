    [TestMethod]
    public async Task TaskRun()
    {
    	Console.WriteLine("Before");
    	Task t = Task.Run(() => Console.WriteLine(IWillBeBack()));
    	Console.WriteLine("After");
    	await t;
    }
    
    private string IWillBeBack()
    {
    	Thread.Sleep(3000);
    	return "I will be back";
    }
