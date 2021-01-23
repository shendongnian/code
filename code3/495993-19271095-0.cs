    class Program
    	{
    		static void Main(string[] args)
    		{
    			CreateClass();
    			Console.Write("Collecting... ");
    			GC.Collect();
    			GC.WaitForPendingFinalizers();
    			Console.WriteLine("Done");
    
    			Console.ReadLine();
    		}
    
    		static void CreateClass()
    		{
    			SomeClass c = new SomeClass();
    			c = null;
    		}
    	}
    
    	class SomeClass
    	{
    		~SomeClass()
    		{
    			Console.WriteLine("Finalized...");
    		}
    	}
