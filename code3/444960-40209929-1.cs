    using Timer = System.Timers.Timer;
    
     
    
    [STAThread]
    
    static void Main(string[] args)
    
    {
    
    Timer t = new Timer(1800000); // 1 sec = 1000, 30 mins = 1800000 
    
    t.AutoReset = true;
    
    t.Elapsed += new System.Timers.ElapsedEventHandler(t_Elapsed);
    
    t.Start();
    
    }
    
    private static void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    
    {
    
    // do stuff every 30  minute
    
    }
