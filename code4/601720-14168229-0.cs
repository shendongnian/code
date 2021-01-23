    class test
    {
    }
    static class x
    {
        public static IEnumerator<object> GetEnumerator(this test t) { return null; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var i in new test()) {  }
        }
    }
