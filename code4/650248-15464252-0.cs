    static class DerivedClass
    {
        public static string GetVal()
        {
            return GetValInternal();
        }
    
        private static string GetValInternal()
        {
            return "Hello";
        }
    }
