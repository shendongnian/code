    var dictionary = new Dictionary<string, int>();
    foreach (var group in array) {
        var fields = group.Split(':');
        int value;
        if (!dictionary.TryGetValue(fields[0], out value)) {
            dictionary.Add(fields[0], 0);
        }
        dictionary[fields[0]] += Int32.Parse(fields[1]);
    }
    string[] foo = new string[dictionary.Count];
    int index = 0;
    foreach (var kvp in dictionary) {
        foo[index++] = String.Format("{0}:{1}", kvp.Key, kvp.Value);
    }
