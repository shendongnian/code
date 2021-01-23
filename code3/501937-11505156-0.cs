    Start
    End
    0
    1
    2
    3
    4
    Console.WriteLine("Start");
    
    Task task = Task.Factory.StartNew(() =>
    {
    
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(i);
        }
    
    });
    
    Console.WriteLine("End");
    Console.ReadLine();
