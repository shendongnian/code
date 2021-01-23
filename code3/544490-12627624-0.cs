	using System;
	class Program
	{
		static void Main(string[] args)
		{
			int x = 2;
			int y = 20;
			
			
			Console.WriteLine("SUM  :: " + AddByValue(x, y));  // Call by value
			Console.WriteLine("X :: " + x + ", Y :: " + y);  // Nothing change to variable
			
			Console.WriteLine("SUM  :: " + AddByRef(ref x, ref y));  // Call by reference
			Console.WriteLine("X :: " + x + ", Y :: " + y);  // Value changed
			
		}
		static int AddByValue(int x, int y)
		{
			int ans = x + y;
			 x = 20;
			 y = 40;
		   return ans;
		}
		
		static int AddByRef(ref int x, ref int y)
		{
			int ans = x + y;
			x = 20;
			y = 40;
		   return ans;
		}
		
		
	}
	
