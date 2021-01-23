    var dict = someObj.DumpProperties();
    var dumpStr = String.Join("\n", 
                          dict.Select(kv => kv.Key + "=" + kv.Value ?? kv.ToString()));
.
    public static class MyExtensions
    {
        public static Dictionary<string, object> DumpProperties(this object obj)
        {
            var props = obj.GetType()
                .GetProperties()
                .ToDictionary(p => p.Name, p => p.GetValue(obj, null));
            return props;
        }
    }
