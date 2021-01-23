            var test = new List<List<string>> ();
            for (int i = 0; i < 1000; i++)
            {
                test.Add(null);
            }
            int finalcount = 0;
            int itemcount = 0;
            int loopcount = 0;
            
            Parallel.ForEach(test, () => new List<string>(),
                (item, loopState, index, loop) =>
                {
                    Interlocked.Increment(ref loopcount);
                    loop.Add("a");
                    //Thread.Sleep(100);
                    return loop;
                },
                l =>
                {
                    Interlocked.Add(ref itemcount, l.Count);                    
                    Interlocked.Increment(ref finalcount);                    
                });
