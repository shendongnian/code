    Dictionary<string, Delegate> dispatch = new Dictionary<string, Delegate>();
    dispatch["help"] = new Action(() => Console.WriteLine("Hello"));
    dispatch["dosomething"] = new Action<string>(s => Console.WriteLine(s));
    dispatch["help"].DynamicInvoke();
    dispatch["dosomething"].DynamicInvoke("World");
