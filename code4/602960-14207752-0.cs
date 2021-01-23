    public void Main()
    {
        var myTimer = new Timer(20000);
    
        myTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
    
        myTimer.Enabled = true;
    
        Console.ReadLine();
    }
    
    
    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
            Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);
    }
