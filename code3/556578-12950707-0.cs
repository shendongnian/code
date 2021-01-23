    static IEnumerable<string> ModifiedLines(string file) {
        string line;
        using(var reader = File.OpenText(file)) {
            while((line = reader.ReadLine()) != null) {
                string[] tokens = line.Split(new char[] { ' ' });
                line = string.Empty;
                foreach (var token in tokens)
                {
                    line += token.TrimStart('0') + " ";
                }
                yield return line;
            }
        }
    }
