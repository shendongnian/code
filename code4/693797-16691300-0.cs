    public class A
    {
        public static string token;
    }
    // ...
    public class Main : B
    {
        public Main()
        {
            string token = A.token;
        }
    }
