    public void processinThreads()
    {
        for (int i = 0; i < 20; i++)
        {
            int local = i;
            Thread t = new Thread(new ThreadStart(()=>DoSomething(local, processCallback)));
            t.Start();
        }
    }
