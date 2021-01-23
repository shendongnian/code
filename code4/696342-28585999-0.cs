    static class GeneralMethods
    {
        public static void Testing(this object This)
        {
            This.ToString().Dump("Testing");
        }
    
        public static void Test2<T>(this T This)
        {
            This.Dump("Test2");
        }
    
    }
