	using System;
	using System.Diagnostics;
	using System.Text.RegularExpressions;
	namespace ConsoleApplication1 {
		internal class Program {
			private static void Main(string[] args) {
				var pattern = new Regex(@"\bN\b");
				const string input = "N foo N bar N";
				MatchCollection matches = pattern.Matches(input);
				Debug.Assert(matches.Count == 3);
				foreach (Match m in matches) {
					Console.WriteLine(m.Value);
				}
			}
		}
	}
