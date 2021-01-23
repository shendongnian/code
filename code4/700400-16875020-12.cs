    var t1 = new Task(() => Console.WriteLine("Completed t1"));
    var t2 = new Task(() => Console.WriteLine("Completed t2"));
    var t3 = new Task(() => Console.WriteLine("Completed t3"));
    t1.ContinueWith(task1 =>
    {
        Console.WriteLine(task1.Result);
    
        t2.ContinueWith(task2 =>
        {
            Console.WriteLine("{0} | {1}", task1.Result, task2.Result);
    
            t3.ContinueWith(task3 =>
            {
                Console.WriteLine("{0} | {1} | {2}", 
                    task1.Result, task2.Result, task3.Result);
            });
    
            t3.Start();
        });
    
        t2.Start();
    });
    
    t1.Start();
    /* OUTPUT:
    Completed t1
    Completed t1 | Completed t2
    Completed t1 | Completed t2 | Completed t3 */
