    using System;
    using System.Text.RegularExpressions;
    
    namespace StackOverLoadTest {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			var s = new RandomString("[Hello|Hi] guys. This is my [code|string]. [I|You|We] should [walk] to the [park|field|farm] [today|tomorrow|next week].");
			for (int i = 0; i < 10; i++)
				Console.WriteLine(s);
		}
	}
	public class RandomString {
		private Random _rnd = new Random();
		private static Regex _rex = new Regex(@"\[ ( \|?  (?<option>[^]|]+) )+ \]", System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace | System.Text.RegularExpressions.RegexOptions.ExplicitCapture);
		string _template;
		public RandomString(string template) {
			_template = template;
		}
		public override string ToString() {
			return _rex.Replace(_template, GetRandomOption);
		}
		public string GetRandomOption(Match m) {
			var options = m.Groups["option"].Captures;
			int choice = _rnd.Next(0, options.Count);
			return options[choice].Value;
		}
	}
    }
