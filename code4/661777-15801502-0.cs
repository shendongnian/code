    using System;
    using System.Threading;
    
    namespace Input
    {
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    			// This is to stop the worker thread
    			var workerShouldStop = false;
    
    			var worker = new Thread(() => 
    			{
    				// do work
    				while (!workerShouldStop) {
    					Thread.Sleep(1000);
    					Console.WriteLine("doing things ...");
    				};
    			});
    
    			worker.Start();
    
    			string input;
    			do 
    			{
    				Console.Write ("Your input (enter to quit):");
    				input = Console.ReadLine();
    				Console.WriteLine("input is:" + input);
    			} while(!String.IsNullOrWhiteSpace(input));
    			// Stop the worker thread
    			workerShouldStop = true;
    		}
    	}
    }
        
