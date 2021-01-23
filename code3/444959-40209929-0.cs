    using Timer = System.Timers.Timer;
    
     
    
    [STAThread]
    
    static void Main(string[] args)
    
    {
    
    Timer t = new Timer(60000); // 1 sec = 1000, 60 sec = 60000
    
    t.AutoReset = true;
    
    t.Elapsed += new System.Timers.ElapsedEventHandler(t_Elapsed);
    
    t.Start();
    
    }
    
    private static void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    
    {
    
    // do stuff every minute
    
    }
