    namespace TestLibrary
    {
        public static class Test
        {
            public static readonly Action<string> WriteLine =
                msg => Console.WriteLine(msg);
        }
    }
