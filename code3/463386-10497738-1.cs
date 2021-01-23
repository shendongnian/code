	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Management;
	
	namespace Test
	{
		class Program
		{
			public class PowerValues
			{
				public double power;
				public double powerR;
				public double lightbulbs;
				public double lightbulbsR;
			}
			
			public static void DoSomething(IEnumerable<PowerValues> powerValues, Func<PowerValues, double> criteria, double treshhold)
			{
				var flaggedElements = powerValues.Where(e => criteria(e) > treshhold);
				foreach (var flagged in flaggedElements)
				{
					Console.WriteLine("Value flagged: {0}", criteria(flagged));
				}
			}
			
			public static void Main(string[] args)
			{
				List<PowerValues> powerValues = new List<PowerValues>();
				
				powerValues.Add(new PowerValues(){power=10, powerR=0.002, lightbulbs = 2, lightbulbsR = 2.006});
				powerValues.Add(new PowerValues(){power=5, powerR=0.004, lightbulbs = 4, lightbulbsR = 2.09});
				powerValues.Add(new PowerValues(){power=6, powerR=0.003, lightbulbs = 3, lightbulbsR = 2.016});
				
				Console.WriteLine("Power matching criteria . . . ");
				DoSomething(powerValues, (e) => e.powerR, 0.003);
			    Console.WriteLine("Lightbulbs matching criteria . . . ");
				DoSomething(powerValues, (e) => e.lightbulbs, 3);
				
				Console.Write("Press any key to continue . . . ");
				Console.ReadKey(true);
			}
		}
	}
