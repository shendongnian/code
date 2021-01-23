	using System;
	using System.Text.RegularExpressions;
	namespace FrenchRegex
	{
		class Program
		{
			static void Main(string[] args)
			{
				var a = "ca va";
				var b = "ça va";
				var regex = @"\b((c|ç)a\sva)";
				var matchA = Regex.Match(a, regex).Success;
				var matchB = Regex.Match(b, regex).Success;
				Console.WriteLine("Matches '" + a + "': " + matchA);
				Console.WriteLine("Matches '" + b + "': " + matchB);
				Console.ReadKey();
			}
		}
	}
