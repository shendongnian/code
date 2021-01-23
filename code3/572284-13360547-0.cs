	[TestMethod]
	public async Task Example()
	{
		var result = await GetSomeData(); //<-- breakpoint
		Assert.IsNotNull(result);
	}
	private async string GetSomeData()
	{
		//TODO something that makes a web request with, say, HttpClient
	}
