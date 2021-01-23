    using System;
	namespace LimitsTest
	{
		class Functions
		{
			public static double OneDividedByX(double x)
			{
				return 1 / x;
			}
			public static double XDividedByX(double x)
			{
				return x / x;
			}
			public static double OneDividedByXSquared(double x)
			{
				return 1 / Math.Pow(x, 2);
			}
			public static double XDividedByXPlusTwo(double x)
			{
				return x / (x + 2);
			}
		}
		class Program
		{
			static double LeftLimit(double x, Func<double, double> function)
			{
				return function(x - double.Epsilon);
			}
			static double RightLimit(double x, Func<double, double> function)
			{
				return function(x + double.Epsilon);
			}
			static double Limit(double x, Func<double, double> function)
			{
				double right = LeftLimit(x, function);
				double left = RightLimit(x, function);
				return (right == left) ? right : double.NaN;
			}
			static void ShowLimits(double x, string description, Func<double, double> function)
			{
				Console.WriteLine("{0} at {1}: {2}", description, x, function(x));
				Console.WriteLine("Limit of {0} as approached from the left of {1}: {2}",
					description, x, LeftLimit(x, function));
				Console.WriteLine("Limit {0} as approached from the right of {1}: {2}",
					description, x, RightLimit(x, function));
				Console.WriteLine("Limit of {0} as approached from {1}: {2}",
					description, x, Limit(x, function));
				Console.WriteLine();
			}
			static void Main(string[] args)
			{
				ShowLimits(0, "1 / x", Functions.OneDividedByX);
				ShowLimits(0, "x / x", Functions.XDividedByX);
				ShowLimits(0, "1 / x^2", Functions.OneDividedByXSquared);
				ShowLimits(-2, "x / (x + 2)", Functions.XDividedByXPlusTwo);
				Console.ReadLine();
			}
		}
	}
