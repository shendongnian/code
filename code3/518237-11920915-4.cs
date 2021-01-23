    Timer actualTimer = new Timer();
    actualTimer.Interval = 1000;
    actualTimer.Elapsed += (sender, e) => Console.WriteLine("Timer!");
    actualTimer.Start();
    Timer killingTimer = new Timer();
    killingTimer.Interval = 5000;
    killingTimer.Elapsed += (sender, e) =>
    {
        Console.WriteLine("Killing timer!");
        actualTimer.Stop();
        killingTimer.Stop();
    };
    killingTimer.Start();
    
