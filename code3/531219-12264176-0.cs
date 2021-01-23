    class MemTest
    {
        private static object[] TakeUpSpace = new object[1024 * 1024];
        public static void Main(string[] args)
        {
            var arr = TakeUpSpace;//make sure it's instantiated.
            Console.ReadKey(true);//keep running so we can profile.
        }
    }
