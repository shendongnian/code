    class Program {
        private static Regex _filterRegex = new Regex(@"[0-9]+", RegexOptions.Compiled);
        static void Main(string[] args) {
          foreach (Match match in _filterRegex.Matches("1,2,3,4,5,6")) {
            Console.WriteLine("Match: " + match.Value);
          }
        }
      }
