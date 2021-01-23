    public Dictionary<int, List<String>> ParseFile(String fileName, int[] indexes)
        var file = File.OpenText(myFile);
        var dict = indexes.ToDictionary(i => i, i => new List<string>());
                
        while(!file.EndOfStream)
        {
            var line = file.ReadLine().Split('|');
            foreach(var entry in dict)
                entry.Value.Add(line[entry.Key]);
        }
        file.Dispose();
        return dict;
    }
