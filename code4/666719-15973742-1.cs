    public void TimingDestructive()
    {
        Timer Time = new Timer();
        Time.startTime();
        DestructiveReverseDeveloped();
        Time.stopTime();
        Console.WriteLine("Time taken for Destructive Reverse of Developed : {0}ms",Time.result().TotalMilliseconds);
        Console.WriteLine("---------------------------------------------------------");
