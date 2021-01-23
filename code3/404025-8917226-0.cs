    class Program
    {
        static void Main(string[] args)
        {
            System.Timers.Timer timer = new System.Timers.Timer(2000);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedObject);
            timer.Start();
            while (true)
            {
            }
        }
        static void OnTimedObject(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("entered");
            Thread.Sleep(3000);
            Console.WriteLine("exited");
        }
    }
