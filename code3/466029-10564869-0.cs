    public static Dictionary<K,T> GetFromDb<K,T>(Func<Reader,KeyValuePair<K,T> maker) {
        var res = new Dictionary<K,T>();
        // ... your code ...
            while (reader.Read()) {
                res.Add(maker(reader));
            }
        return res;
    }
