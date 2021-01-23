		private static void Main(string[] args) {
			var list = new List<string> {
				"BEREŽALINS",
				"GŽIBOVSKIS",
				"TEST"
			};
			var pat = new Regex(@"[^\u0000-\u007F]");
			foreach (var name in list) {
				Console.WriteLine(string.Concat(name, " = ", pat.IsMatch(name) ? "Match" : "Not a Match"));
			}
			Console.ReadLine();
		}
