    class Program {
        private static Regex _filterRegex = new Regex(@"[0-9]+", RegexOptions.Compiled);
        private static void FindMatches() {
          foreach (Match match in _filterRegex.Matches("1,2,3,4,5,6")) {
            Console.WriteLine("Match: " + match.Groups[0].Value);
          }
        }
        static void Main(string[] args) {
          FindMatches();
        }
      }
