    using System;
    using System.Threading.Tasks;
    					
    public class Program
    {
    	public static void Main()
    	{				
    		var a = MyMethodAsync(); //Task started for Execution and immediately goes to Line 19 of the code. Cursor will come back as soon as await operator is met		
    		Console.WriteLine("Cursor Moved to Next Line Without Waiting for MyMethodAsync() completion");
    		Console.WriteLine("Now Waiting for Task to be Finished");		
    		Task.WaitAll(a); //Now Waiting		
    		Console.WriteLine("Exiting CommandLine");		
    	}
    	
    	public static async Task MyMethodAsync()
    	{
    		Task<int> longRunningTask = LongRunningOperation();
    		// independent work which doesn't need the result of LongRunningOperationAsync can be done here
    		Console.WriteLine("Independent Works of now executes in MyMethodAsync()");
    		//and now we call await on the task 
    		int result = await longRunningTask;
    		//use the result 
    		Console.WriteLine("Result of LongRunningOperation() is " + result);
    	}
    
    	public static async Task<int> LongRunningOperation() // assume we return an int from this long running operation 
    	{
    		Console.WriteLine("LongRunningOperation() Started");
    		await Task.Delay(2000); // 2 second delay
    		Console.WriteLine("LongRunningOperation() Finished after 2 Seconds");
    		return 1;
    	}	
    	
    }
