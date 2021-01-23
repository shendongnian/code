            int noOfProcess = 4;
            Task[] t = new Task[noOfProcess];
            for (int i = 0; i < noOfProcess; i++)
            {
               t[i]= Task.Factory.StartNew(() =>
                {
                    Parallel.For(0, 2500, (v) => game(..));
                });
            }
            Task.WaitAll(t); //If Synchronous is needed.
