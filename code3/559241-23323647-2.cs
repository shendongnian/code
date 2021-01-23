    using system.timers;
    static void Main(string[] args)()
    {
        Timer t = new Timer(TimeSpan.FromMinutes(5).TotalMiliseconts); // set the time (5 min in this case)
        t.AutoReset = true;
        t.Elapsed += new System.Timers.ElapsedEventHandler(your_method);
        t.Start();
    }
    // this method calls every 5 min
    private void your_method(object sender, ElapsedEventArgs e)
    {
        Console.WriteLine("..."); 
    }
 
