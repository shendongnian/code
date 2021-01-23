            int n = 2;
            Task[] producers = Enumerable.Range(1, 3).Select(_ => 
                Task.Factory.StartNew(() =>
                    {
                        while (queue.Count < n)
                        {
                            lock (queue)
                            {
                                if (!queue.Contains(n))
                                {
                                    Console.WriteLine("Thread" + Task. CurrentId);
                                    queue.Add(n);
                                    Interlocked.Increment(ref n);
                                }
                            }
                            Thread.Sleep(100);
                        }
                    }))
                .ToArray();
