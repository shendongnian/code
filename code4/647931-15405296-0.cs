    static class Program
    {
        static System.Timers.Timer _timer;
        static void Main(string[] args)
        {
            DoLater(SayHello, 5000);
            Console.ReadLine();
        }
        public static void DoLater(this Action handler, int delay)
        {
            _timer = new System.Timers.Timer(delay);
            _timer.Elapsed += new ElapsedEventHandler(delegate {
                                       handler();
                                       _timer.Dispose();
                                    });
            _timer.Enabled = true;
        }
        public static void SayHello()
        {
            MessageBox.Show("Hello World");
        }
    }
