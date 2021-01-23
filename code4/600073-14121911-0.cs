        int item;
        lock (SharedMemory)
        {
            while (SharedMemory.Count == 0)
            {
                Monitor.Wait(SharedMemory);
            }
            item = SharedMemory.Pop();
        }
        Console.WriteLine(item);
