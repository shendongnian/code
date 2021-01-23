    RefAction<Action<string>> docollectprint = (ref Action<string> vl) =>
    {
        vl = vlocres =>
        {
            //DoStuff
        };
        //Action has been set
        Console.WriteLine((vl == null).ToString());
    };
    Action<string> action = null;
    docollectprint(ref action);
    //Action is still set
    Console.WriteLine((action == null).ToString());
