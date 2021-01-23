    class Program
    {
        public static void Run()
        {
            Console.WriteLine("Running");
        }
        public static int RunAtSpeed(int speed)
        {
             // logic to run @ speed and return time
             Console.WriteLine("Running @ {0}", speed); 
             return 10;
        }
        public static int WalkAtSpeed(int speed)
        {
             // logic to walk @ speed and return time
             Console.WriteLine("Walking @ {0}", speed); 
             return 20;
        }
    
        static void Main()
        {
            Action foo = Run; 
            foo(); 
            MoveDelegate run = RunAtSpeed;
            int result1 = run(5);
            MoveDelegate walk = WalkAtSpeed;
            int result2 = walk(1);
        }
    }
