    static void Main(string[] args)
        {
            BufferBlock<int> bb = new BufferBlock<int>();
            ActionBlock<int> a1 = new ActionBlock<int>((a) =>
                                                        {
                                                            Thread.Sleep(100);
                                                            Console.WriteLine("Action A1 executing with value {0}", a);
                                                        }
                                                      );
            ActionBlock<int> a2 = new ActionBlock<int>((a) =>
                                                        {
                                                            Thread.Sleep(50);
                                                            Console.WriteLine("Action A2 executing with value {0}", a);
                                                        }
                                                      );
            ActionBlock<int> a3 = new ActionBlock<int>((a) =>
                                                        {
                                                            Thread.Sleep(50);
                                                            Console.WriteLine("Action A3 executing with value {0}", a);
                                                        }
                                                      );
            bb.LinkTo(a1);
            bb.LinkTo(a2);
            bb.LinkTo(a3);
            Task t = new Task(() =>
                                {
                                    int i = 0;
                                    while (i < 10)
                                    {
                                        Thread.Sleep(50);
                                        i++;
                                        bb.Post(i);
                                    }
                                }
                             );
            t.Start();
            Console.Read();
        }
