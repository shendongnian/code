    Semaphore sem = new Semaphore(3,3);
    while (true)
    {
         if ( acci.Count > 0 )
         {
            ac = acci.Pop();
            if (ac != "")
            {
                new Thread(delegate() 
                       {
                         sem.WaitOne();
                         Console.WriteLine("Run " + ac.Name);
                         Go(ac);
                         sem.Release();
                       }).Start();
            }
        }
        else
        {
            break;
        }
    }
