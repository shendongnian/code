    public static class ExtensionMethods
    {
        private static System.Runtime.CompilerServices.ConditionalWeakTable<object, object> extendedData = new System.Runtime.CompilerServices.ConditionalWeakTable<object, object>();
    
        internal static IDictionary<string, object> CreateDictionary(object o) {
            return new Dictionary<string, object>();
        }
    
        public static void SetExtendedDataValue(this object o, string name, object value) {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Invalid name");
            name = name.Trim();
    
            IDictionary<string, object> values = (IDictionary<string, object>)extendedData.GetValue(o, ExtensionMethods.CreateDictionary);
    //            if (values == null)
    //                extendedData.Add(o, values = new Dictionary<string, object>()); // This doesn't seem to be necessary!
    
            if (value != null)                 
                values[name] = value;
            else
                values.Remove(name);
        }
    
        public static T GetExtendedDataValue<T>(this object o, string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Invalid name");
            name = name.Trim();
    
            IDictionary<string, object> values = (IDictionary<string, object>)extendedData.GetValue(o, ExtensionMethods.CreateDictionary);
    //            if (values == null) // ... nor does this!
    //                return default(T);
    //            else 
            if (values.ContainsKey(name))
                return (T)values[name];
            else
                return default(T);
        }
    
        internal static object GetExtendedDataValue(this object o, string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Invalid name");
            name = name.Trim();
    
            IDictionary<string, object> values = (IDictionary<string, object>)extendedData.GetValue(o, null);
            if (values == null)
                return null;
            else if (values.ContainsKey(name))
                return values[name];
            else
                return null;
        }
    }
