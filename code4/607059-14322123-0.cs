            ItemsList il = new ItemsList();
            Task ts = new Task(() =>
            {
                for (int i = 0; i < 100000; i++)
                {
                    il.Add(i);
                    System.Threading.Thread.Sleep(100);
                }
            }
            );
            ts.Start();
            Task ts2 = new Task(() =>
            {
                //DoSomeActivity
                il.IncrementAll();
            }
            );
            ts2.Start();
            Console.Read();
