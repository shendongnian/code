    // AllMethods.cs
    namespace Some.Namespace
    {
        public class AllMethods
        {
            public static void Method2()
            {
                // code here
            }
        }
    }
    // Caller.cs
    using static Some.Namespace.AllMethods;
    namespace Other.Namespace
    {
        class Caller
        {
            public static void Main(string[] args)
            {
                Method2(); // No need to mention AllMethods here
            }
        }
    }
