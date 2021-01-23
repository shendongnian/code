    Action<string> action = s => Console.WriteLine("Hello " + s);
    object obj = action;
    // Invoking
    obj.GetType ().GetMethod ("Invoke").Invoke (obj, new object[] {"World"});
 
