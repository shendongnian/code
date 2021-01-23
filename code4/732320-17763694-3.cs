        public static string SaveSomething;
        public static void DoSomething()
        {
            lock (SaveSomething)
            {
                 SaveSomething = "something";
                 //... do more code
                 AnotherAction(SaveSomething);
            }
        }
