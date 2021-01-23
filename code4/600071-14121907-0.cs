            int item;
            SharedMemory = new ConcurrentStack<int>();
            var addItem = Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(2);
                    SharedMemory.Push(2);
                });
            while (!SharedMemory.TryPop(out item))
            {
                Monitor.Wait(SharedMemory);
            }
            Console.WriteLine(item);
