    Task<IEnumerable<int>> GetSomething()
    {
    	return Task.Factory.StartNew(() => { 
    		Thread.Sleep(2000);
    		throw new Exception(); 
    		return (new List<int> { 1, 2, 3 }).AsEnumerable(); 
    		});
    }
