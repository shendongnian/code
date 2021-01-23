    class Program
    {
        static void Main(string[] args)
        {
            Delegate barInit = (Action)(() => DoNothing());
            Delegate fooInit = new Action(() => DoNothing());
        }
        private static void DoNothing() { }
    }
