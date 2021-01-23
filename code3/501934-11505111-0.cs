    Console.WriteLine ("Start");
    Task task = Task.Factory.StartNew(() => {
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine (i);
    }
    });
    
    Console.ReadLine();
    Console.WriteLine("End");
