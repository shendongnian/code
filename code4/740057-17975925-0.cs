    var lines = new List<string>();
    using (var sr = new StringReader(str)) {
        string line;
        while ((line = sr.ReadLine()) != null) {
            lines.Add(line);
        }
    }
    string[] strsplit = lines.ToArray();
