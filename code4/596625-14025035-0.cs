    static void Supervisor()
    {
        while (true)
        {
            DateTime time = ReadTimeFromFile();
    
            if (Math.Abs((DateTime.Now - time).TotalMinutes) <= 1)
            {
                DeleteTimeFile(); // to indicate task is done
    
                RunTask();
    
                break;
            }
    
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }
    }
