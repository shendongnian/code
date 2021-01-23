    public class Sample
    {
        public static string _sharedVariable = string.Empty;
        public static void DoSomething()
        {
            string result = DoSomethingElse();
            // Can access _sharedVariable here
        }
        protected static string DoSomething()
        {
            _sharedVariable = "hello world";
            return "sup";
        }
    }
