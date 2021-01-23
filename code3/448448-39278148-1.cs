     static void Main()
     {
        ILogger log = new Log();
        Arithmatic obj = new Arithmatic(log);
        obj.Calculate(10, 3);
        Console.ReadLine();
     }
