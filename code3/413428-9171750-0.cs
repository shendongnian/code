	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	namespace DerivationTest
	{
		class Program
		{
			public class Thing
			{
				public Thing()
				{
					Console.WriteLine("Thing");
				}
			}
			public class ThingChild : Thing
			{
				public ThingChild()
				{
					Console.WriteLine("ThingChild");
				}
			}
			static void Main(string[] args)
			{
				var tc = new ThingChild();
				Console.ReadLine();
			}
		}
	}
