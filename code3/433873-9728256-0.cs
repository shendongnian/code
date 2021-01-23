    ThreadPool.SetMinThreads(20, 20);
    int activeWorkers = 0;
    object signal = new object();
    foreach(/* server in listView2 */)
    {
        foreach(/* email in listView1 */)
        {
            lock(signal) ++activeWorkers; // keep track of active workers
            ThreadPool.QueueUserWorkItem(
                o =>
                {
                    string email = (string)o;
                    startsend(server, email);                   
                    lock(signal) // signal termination
                    {
                       --activeWorkers;
                       Monitor.Pulse(signal);                    
                    }
                }, email);
            lock(signal) 
            {
               while(activeWorkers > 0) // improvised barrier
                   Monitor.Wait(signal);
            }
        }
    }
