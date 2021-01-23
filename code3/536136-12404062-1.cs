         string value = MyLookupTable.GetValue(1); // First Value
         value = MyLookupTable.GetValue(2); // Second Value
         value = MyLookupTable.GetValue(3); // Third Value
    class MyLookupTable
    {
        private static Dictionary<int, string> lookupValue = null;
        
        private MyLookupTable() {}
    
        public static string GetValue(int key)
        {
            if (lookupValue == null || lookupValue.Count == 0)
                AddValues();
    
            if (lookupValue.ContainsKey(key))
                return lookupValue[key];
            else
                return string.Empty; // throw exception
        }
    
        private static void AddValues()
        {
            if (lookupValue == null)
            {
                lookupValue = new Dictionary<int, string>();
                lookupValue.Add(1, "First Value");
                lookupValue.Add(2, "Second Value");
                lookupValue.Add(3, "Third Value");
            }
        }
    }
