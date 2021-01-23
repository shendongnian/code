    public static class ObjectFactory
    {
        public static dynamic CreateInstance(Dictionary<string, string> objectFromFile)
        {
            dynamic instance = new ExpandoObject();
            var instanceDict = (IDictionary<string, object>)instance;
            foreach (var pair in objectFromFile)
            {
                instanceDict.Add(pair.Key, pair.Value);
            }
            return instance;
        }
    }
