    public class Program
    {
        public static void Main(string[] args)
        {
            Timer myTimer = new Timer(TimerTick, // the callback function
                new object(), // some parameter to pass
                0, // the time to wait before the timer starts it's first tick
                1000); // the tick intervall
        }
        private static void TimerTick(object state)
        {
            // less then .NET 4.0
            Thread newThread = new Thread(CallTheBackgroundFunctions);
            newThread.Start();
            // .NET 4.0 or higher
            Task.Factory.StartNew(CallTheBackgroundFunctions);
        }
        private static void CallTheBackgroundFunctions()
        {
            cpuView();
            gpuView();
        }
    }
