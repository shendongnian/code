    var counts = new Dictionary<char,int>();
    foreach(char c in text) {
        int count;
        counts.TryGetValue(c, out count);
        counts[c] = count + 1;
    }
    var sorted = counts.OrderByDescending(kvp => kvp.Value).ToArray();
    foreach(var pair in sorted) {
        Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
    }
    
