    class Program
    {
        static void Main(string[] args)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 5, 0); // sets it to 5 minutes
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
    
        static void timer_Tick(object sender, EventArgs e)
        {
            // whatever you want to happen every 5 minutes
        }
    
    }
