    public long RecursivePLINQ(long factor,long total)
        {
            if(total == 0)
            {
                total = 1;
            }
            if (factor > 1)
            {
                Parallel.For<long>(0, 1, () => factor, (j, loop, factorial) =>
                {
                    Thread.Sleep(1);    /*Simulate Moderate Operation*/
                    total = factorial * RecursivePLINQ(--factorial, total);
                    return total;
                }, (i) =>  {return;});
            }
            return total;
        }
