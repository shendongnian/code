    public static class LinqToTextReader {
        public static IEnumerable<string> AsEnumerable(this TextReader reader) {
            string line;
            while ((line = reader.ReadLine()) != null) {
                yield return line;
            }
        }
    }
    
    class Program {
        static void Main(string[] args) {
            using (StreamReader reader = new StreamReader("file.dat")) {
                var locations = new Dictionary<string, int[]>() {
                    {"210", new [] {406, 409, 129, 140, 142, 153}},
                    {"310", new [] {322, 325, 113, 124, 126, 137}},
                    {"410", new [] {478, 481, 113, 124, 126, 137}}
                };
                var query =
                    from line in reader.AsEnumerable()
                    let lineStart = line.Substring(0, 3)
                    where lineStart == "210" || lineStart == "310" || lineStart == "410"
                    let currentLocations = locations[lineStart]
                    select new {
                        letters = line.Substring(currentLocations[0], currentLocations[1]),
                        value =
                            int.Parse(line.Substring(currentLocations[2], currentLocations[3])) +
                            int.Parse(line.Substring(currentLocations[4], currentLocations[5]))
                    };
                //It should be possible to combine the two queries
                var query2 = 
                    from item in query
                    group item by item.letters into letterGroup
                    select new {
                        letters = letterGroup.Key,
                        total = letterGroup.Sum(item => item.value)
                    };
                foreach (var item in query2) {
                    Console.WriteLine(item.letters);
                    Console.WriteLine(item.total);
                }
            }
        }
    }
