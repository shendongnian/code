     private async DeferredFunctionTask<int> WaitForStart(CancellationTokenSource c, string  serviceName)
        {
            
            var t = await Task.Run<int>(() =>
            {
                int ret = 0;
                for (int i = 0; i < 500000000; i++)
                {
                    //ret += i;
                    //if (i % 100000 == 0)
                    //    Console.WriteLine(i);
                    if (c.IsCancellationRequested)
                    {
                        return ret;
                    }
                }
                
                return ret;
            });
            return t;
        }
