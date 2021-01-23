    DelayQueue<string> queue = new DelayQueue<string>();
    queue.Enqueue("world", new TimeSpan(0, 0, 1));
    queue.Enqueue("hello");                        
    queue.Enqueue(",");
    
    TimeSpan timeout = new TimeSpan(0, 0, 2);
    Console.WriteLine(queue.Dequeue());
    Console.WriteLine(queue.Dequeue(timeout));
    Console.WriteLine(queue.Dequeue(timeout));
