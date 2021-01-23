    using System;
    
    namespace ConsoleApplication6
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			int count = 123;
    			string nl = string.Empty;
    			Console.WriteLine($@"Abc {count} def {count
    				} ghi {
    				count} jkl{nl
    				} mno");
    			Console.ReadLine();
    		}
    	}
    }
