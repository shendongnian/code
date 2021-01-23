    public class Play {
        static IEnumerable<string> ReadLines(string filename) {
            using (TextReader reader = new StreamReader(filename)) {
                var headers = reader.ReadLine(); // I'm guessing you want to ignore this??
                while (true) {
                    string line = reader.ReadLine();
                    if (line == null)
                        yield break;
                    yield return line;
                }
            }
        }
        public static void Main(string[] args) {
            foreach (string line in ReadLines("Input.tsv"))
                Console.WriteLine(line);
        }
    }
