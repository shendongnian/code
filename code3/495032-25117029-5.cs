    // Example of static and non-static methods and how to call
    namespace TestStaticVoidMain
    {
    	class Program
    	{
    		Static Void Main(string[] args)
    		{
    		   // Instantiate or create object of the non-static method:
    			Exam ob = new Exam();
    			// Call the instance:
    			ob.Test1();
    			// Directly the call the static method by its class:
    			Exam.Test2();
    			Console.ReadKey();
    		}
    	}
    	class Exam
    	{
    		public void Test1()
    		{
    			Console.WriteLine("This is a non-static method");
    		}
    		public static void Test2()
    		{
    			Console.WriteLine("This is a static method");
    		}
    	}
    }
