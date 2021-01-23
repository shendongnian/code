        public static class NameValueCollectionExtension
        {
            public static IDictionary<string, string> ToDictionary(this NameValueCollection sourceCollection)
            {
                return sourceCollection.Cast<string>()
                         .Select(i => new { Key = i, Value = sourceCollection[i] })
                         .ToDictionary(p => p.Key, p => p.Value);
            }
        }
