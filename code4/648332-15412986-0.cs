    var task =  Task.Factory.StartNew(()=>
                        {
                            LongGetOrAdd(dict, 1);
                        });
        Task.WaitAll(task);
        Console.ReadLine();
