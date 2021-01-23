    var collection = new SynchronizedCollection<int>();
    
    var n = 0;
    
    Task.Run(
        () =>
            {
                while (true)
                {
                    collection.Add(n++);
                    Thread.Sleep(5);
                }
            });
    
    Task.Run(
        () =>
            {
                while (true)
                {
                    Console.WriteLine("Elements in collection: " + collection.Count);
    
                    var x = 0;
                    if (collection.Count % 100 == 0)
                    {
                        foreach (var i in collection)
                        {
                            Console.WriteLine("They are: " + i);
                            x++;
                            if (x == 100)
                            {
                                break;
                            }
    
                        }
                    }
                }
            });
    
    Console.ReadKey();
