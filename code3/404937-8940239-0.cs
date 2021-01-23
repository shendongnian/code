    Timer timer = new Timer();
    timer.Elapsed += (sender, eventArgs) =>
    {
        for (int i = 0; i < 5; i++)
        {
            Console.Write(i);            
        }
    };
