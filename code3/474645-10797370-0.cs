    using System.Text.RegularExpressions;
    class Program {
        static void Main(string[] args) {
            string string1 = "TermSomething";
            string string2 = "term";
            bool test1 = string1.ToUpperInvariant().Contains(string2.ToUpperInvariant());
            bool test2 = Regex.IsMatch(string1, Regex.Escape(string2), RegexOptions.IgnoreCase);
        }
    }
