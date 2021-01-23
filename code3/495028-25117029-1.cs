    //example of static and non-static method and how to call
    namespace TestStaticVoidMain
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    		   //Instantiating or creating object of non-static method 
    			Exam ob = new Exam();
    			ob.Test1();
    			//Directly call static method by its class
    			Exam.Test2();
    			Console.ReadKey();
    		}
    	}
    	class Exam
    	{
    		public void Test1()
    		{
    			Console.WriteLine("This is non-static method");
    		}
    		public static void Test2()
    		{
    			Console.WriteLine("This is static method");
    		}
    	}
    }
    
    
    
