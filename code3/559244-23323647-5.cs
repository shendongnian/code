    using System.Timers;
    static void Main(string[] args)()
    {
        Timer t = new Timer(TimeSpan.FromMinutes(5).TotalMilliseconds); // Set the time (5 mins in this case)
        t.AutoReset = true;
        t.Elapsed += new System.Timers.ElapsedEventHandler(your_method);
        t.Start();
    }
    // This method is called every 5 mins
    private void your_method(object sender, ElapsedEventArgs e)
    {
        Console.WriteLine("..."); 
    }
 
