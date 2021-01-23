    namespace TestCast {
        class Program
        {
            public static T Get<T>(string o) where T : class
            {
                return o as T;
            }
            static void Main(string[] args)
            {
                Get<Breaker>("blah");
            }
        }
    }
