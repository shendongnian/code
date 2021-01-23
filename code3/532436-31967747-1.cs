	using System;
	
	public class Program
	{
		public static void Main()
		{
			string format = "    Convert.ToString({0,-20}) == null? {1,-5},  == empty? {2,-5}";
			object nullObject = null;
			string nullString = null;
			
			string convertedString = Convert.ToString(nullObject);
			Console.WriteLine(format, "nullObject", convertedString == null, convertedString == "");
			
			convertedString = Convert.ToString(nullString);
			Console.WriteLine(format, "nullString", convertedString == null, convertedString == "");
			
			convertedString = Convert.ToString((object)nullString);
			Console.WriteLine(format, "(object)nullString", convertedString == null, convertedString == "");
			
		}
	}
