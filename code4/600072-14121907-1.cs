        int item;
        var SharedMemory = new BlockingCollection<int>(new ConcurrentStack<int>());
        // later in the Consume part
        item = SharedMemory.Take(); // this will block until there is an item in the list
        Console.WriteLine(item);
