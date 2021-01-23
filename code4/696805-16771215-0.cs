    void Main()
    {
        Console.WriteLine ("Main start.");
        int i = 100;
	
        Task<int> t1 = new Task<int>(()=> 
        {
		
	
		Console.WriteLine ("In parent start");
		Task c1 = Task.Factory.StartNew(() => {
			Interlocked.Increment(ref i);
			Console.WriteLine ("In child 1:" + i);
		}, TaskCreationOptions.AttachedToParent);
		
		Thread.Sleep(1000);
		
		Task c2 = Task.Factory.StartNew(() => {
			Interlocked.Increment(ref i);           
			Console.WriteLine ("In child 2:" + i);
		}, TaskCreationOptions.AttachedToParent );
	
		Thread.Sleep(1000);
		
		Console.WriteLine ("In parent end");
		return i;
	}); 
	
	t1.Start();
	Console.WriteLine ("Calling Result.");
	Console.WriteLine (t1.Result);
	Console.WriteLine ("Main end.");
     }
