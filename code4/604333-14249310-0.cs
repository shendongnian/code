    Action<string> action;
    if (DateTime.Today.Day > 10)
    {
        action = (string arg = "boo") => Console.WriteLine(arg); 
    }
    else
    {
        action = (string arg = "hiss") Console.WriteLine(arg);
    }
    action(); // What would the compiler do here?
