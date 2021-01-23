    List<string> list = new List<string>();
    using(StreamReader reader = new StreamReader(path)) {
        string line;
        while((line = reader.ReadLine()) != null) {
            list.Add(line);
        }
    }
    string[] entries = list.ToArray();
