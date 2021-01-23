    List<IWorker> workers = new List<IWorker>();
    using (CountdownEvent e = new CountdownEvent(workers.Count))
    {
        foreach (IWorker worker in workers)
        {
            // Dynamically increment signal count.
            e.AddCount();
            // run work itself on another thread
            ThreadPool.QueueUserWorkItem(delegate(object state)
            {
                try
                {
                    ((IWorker)state[0]).DoWork((DataContainer)state[1]);
                }
                finally
                {
                    e.Signal();
                }
            },
            // pass required parameters for block of work
            new object[] { worker, dataForWorker });
        }
        // wait for all workers to finish
        e.Wait();
        // run callback code
    }
