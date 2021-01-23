    public static class ReadOnly
    {
        private static readonly Dictionary<string, object> values = new Dictionary<string, object>();
        public static bool SetValue(string name, object data)
        {
            if (values.ContainsKey(name))
                return false;
            values[name] = data;
            return true;
        }
        public static object GetValue(string name)
        {
            return values[name];
        }
    }
            ReadOnly.SetValue("xs", 1);
		    ReadOnly.SetValue("xs", 1); // will crash
