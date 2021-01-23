    class MemTest
    {
        private static object[] TakeUpSpace = new object[1024];
        public static void Main(string[] args)
        {
            var arr = TakeUpSpace;//make sure it's instantiated.
            for(var i = 0; i != 1024; ++i)
                arr[i] = new object();
            Console.ReadKey(true);//keep running so we can profile.
        }
    }
