	//Lower level - parts that work differently for sync/async version.
	//When isAsync is false there are no await operators and method is running synchronously.
	private static async Task Wait(bool isAsync, int milliseconds)
	{
		if (isAsync)
		{
			await Task.Delay(milliseconds);
		}
		else
		{
			System.Threading.Thread.Sleep(milliseconds);
		}
	}
	
	//Middle level - the main algorithm.
	//When isAsync is false the only awaited method is running synchronously,
    //so the whole algorithm is running synchronously.
	private async Task<ThirdPartyResult> Execute(bool isAsync, ThirdPartyOptions options)
	{
		ThirdPartyComponent.Start(options);
		await Wait(isAsync, 1000);
		return ThirdPartyComponent.GetResult();
	}
	
	//Upper level - public synchronous API.
	//Internal method runs synchronously and will be already finished when Result property is accessed.
	public ThirdPartyResult ExecuteSync(ThirdPartyOptions options)
	{
		return Execute(false, options).Result;
	}
	//Upper level - public asynchronous API.
	public async Task<ThirdPartyResult> ExecuteAsync(ThirdPartyOptions options)
	{
		return await Execute(true, options);
	}
