	using System;
	namespace Code.Without.IDE
	{
		public class FloatingTypes
		{
			public static void Main(string[] args)
			{
				decimal deci = 1.23456789987654321M;
				decimal decix = 1.23456789987654321987654321987654321M;
				double doub = 1.23456789987654321d;
				Console.WriteLine(deci); // prints - 1.23456789987654321
				Console.WriteLine(decix); // prints - 1.2345678998765432198765432199
				Console.WriteLine(doub); // prints - 1.23456789987654
			}
		}
	}
