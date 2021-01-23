    var lines = new Dictionary<int, List<string>>() {
        { 0, new List<string>() },
        { 1, new List<string>() }
    };
    using (StreamReader sr = new StreamReader(filename)) {
        int i=0;
        while (!sr.EndOfStream) {
            string line = sr.ReadLine();
            lines[i%2].Add(line);
        }
    }
