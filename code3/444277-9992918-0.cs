        foreach(string item in Items)
        {
            string item2 = item;
            Console.WriteLine("Adding {0} to ThreadPool", item2);
            ThreadPool.QueueUserWorkItem
            (
                delegate
                {
                    Load(item2, this.progCall, this.compCall);
                }
            );
            numThreads++;
            Thread.Sleep(100);//Remove this line
        }
