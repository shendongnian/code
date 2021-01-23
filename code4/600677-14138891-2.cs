    public static class DictionaryExtension {
        public static void WriteToCsv<K, V>(
            this IDictionary<K, V> dictionary,
            string path,
            Func<K, string> keyToString,
            Func<V, string> valueToString,
            string separator) {
            StringBuilder content = new StringBuilder();
            foreach (KeyValuePair<K, V> keyValuePair in dictionary)
                content.AppendLine(string.Join(separator, new List<string> {
                    keyToString(keyValuePair.Key),
                    valueToString(keyValuePair.Value)
                }));
            File.WriteAllText(path, content.ToString());
        }
    }
