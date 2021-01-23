    public static class MyFakeEnum
    {
        public static int Value1
        {
            get { return GetActualValue("Value1"); }
        }
    
        public static int Value2
        {
            get { return GetActualValue("Value2"); }
        }
    
        private static int GetActualValue(string name)
        {
            // Put here the code to read the actual value
            // from your favorite source. It can be a database, a configuration
            // file, the registry or whatever else. Consider to cache the result.
        }
    }
