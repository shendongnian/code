                    try
                    {
                        for (int i = 0; i < int.MaxValue; i++)
                        {
                            if (token.IsCancellationRequested)
                            {
                                Console.WriteLine("Task cancel detected");
                                token.ThrowIfCancellationRequested();
                            }
                            else
                            {
                                Console.WriteLine("Int value {0}", i);
                            }
                        }
                    }
                    catch(OperationCanceledException e)
                    {
                        Console.WriteLine("Task cancelled via token!");
                    }
