    public void PerformWork()
    {
    	// setup your inputs
    	IEnumerable<string> inputs = CreateYourInputList();
    
    	//  Method signature: Parallel.ForEach(IEnumerable<TSource> source, Action<TSource> body)
    	Parallel.ForEach(inputs, input =>
    		{
    			// call your code that issues the stored procedure here
    			this.SPCall(input);
    		} //close lambda expression
    	); //close method invocation 
    
    	// Keep the console window open in debug mode.
    	Console.WriteLine("Processing complete. Press any key to exit.");
    	Console.ReadKey();
    }
