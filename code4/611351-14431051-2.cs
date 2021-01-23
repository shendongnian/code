    public void CallSlowStuff()
    {
        actionBlock.Post(null);
    }
    
    private async Task CallActualSlowStuff(object _)
    {
    	using (File.Open("_", FileMode.Create, FileAccess.Write, FileShare.None)) {
    		for (int i = 0; i < 10; i++) {
    			await Task.Factory.StartNew(Console.WriteLine, i);
    			await Task.Delay(100);
    		}
    	}
    }
