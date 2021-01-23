        Console.WriteLine("Waiting for input for 10 seconds...");
        DateTime start = DateTime.Now;
        bool gotKey = false;
        while ((DateTime.Now - start).TotalSeconds < 10)                
        {
            if (Console.KeyAvailable)
            {
                gotKey = true;
                break;
            }            
        }
        if (gotKey)
        {
            string s = Console.ReadLine();
        }
        else
            Console.WriteLine("Timed out");
