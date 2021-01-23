    using System;
    using System.Text.RegularExpressions;
    class RegExSample
    {
    static string CapText(Match m)
        {
            // Return the match in upper case
            return m.ToString().ToUpperInvariant();
        }
        static void Main()
        {
            string text = "Mc'donald";
            System.Console.WriteLine("text=[" + text + "]");
            Regex rx = new Regex(@"'\w");
            string result = rx.Replace(text, new MatchEvaluator(RegExSample.CapText));
            System.Console.WriteLine("result=[" + result + "]");
        }
    }
