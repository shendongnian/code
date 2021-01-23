               DateTime? counter = null;
                while (1 = 1)
                {
                    if (DateTime.Now.Day == 28 && (!counter.HasValue || counter.Value.Date < DateTime.Now.Date ))
                    {
                        counter = DateTime.Now;
                        DoSomething();
                    }
                    Thread.Sleep(1000);
                };
