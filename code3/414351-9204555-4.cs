    namespace TestLibrary
    {
        public static class Test
        {
            public static readonly Action<string> WriteLine =
                msg => Console.WriteLine(msg);
            // the same works if I do this instead
            //public static readonly Action<string> WriteLine = Console.WriteLine;
        }
    }
