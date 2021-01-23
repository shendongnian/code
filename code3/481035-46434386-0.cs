        public static Dictionary<VALUE,KEY> Inverse<KEY,VALUE>(this Dictionary<KEY,VALUE> dictionary)
        {
            if (dictionary==null || dictionary.Count == 0) { return null; }
            
            var result = new Dictionary<VALUE, KEY>(dictionary.Count);
            foreach(KeyValuePair<KEY,VALUE> entry in dictionary)
            {
                result.Add(entry.Value, entry.Key);
            }
            return result;
        }
        public static Dictionary<VALUE, KEY> SafeInverse<KEY, VALUE>(this Dictionary<KEY, VALUE> dictionary)
        {
            if (dictionary == null || dictionary.Count == 0) { return null; }
            var result = new Dictionary<VALUE, KEY>(dictionary.Count);
            foreach (KeyValuePair<KEY, VALUE> entry in dictionary)
            {
                if (result.ContainsKey(entry.Value)) { continue; }
                result.Add(entry.Value, entry.Key);
            }
            return result;
        }
