    using System;
    using System.Text.RegularExpressions;
    namespace regex
    {
	class MainClass
	{
		public static void Main (string[] args)
		{
			string result = matchTest("OG000134W4.11");
			Console.WriteLine(result);
		}
		public static string matchTest (string input)
		{
			Regex rx = new Regex(@"([1-9][0-9]+)\w*[0-9]*\.[0-9]*");
			Match match = rx.Match(input);
			if (match.Success){
				return match.Groups[1].Value;
			}else{
				return string.Empty;
			}
		}
	}
    }
