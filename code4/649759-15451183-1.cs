    ...
    Console.ForegroundColor = ConsoleColor.Black;
    StopWatch sw = new Stopwatch();
    sw.Start();
    string strPassword = Console.ReadLine();
    sw.Stop()
    TimeSpan ts = sw.Elapsed;
    string strTPassword = "testpwd";
    if (strPassword == strTPassword)
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("You are logged in after " + ts.Milliseconds.ToString() + " milliseconds");
        Console.ReadLine();
    }
    .....
   
