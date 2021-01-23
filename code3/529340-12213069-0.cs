    string someString = "42";
    int result;
    if(int.TryParse(someString, out result))
    {
        // It's ok
         Console.WriteLine("ok: " + result);
    }
    else
    {
        // it's not ok
        Console.WriteLine("Shame on you");
    }
