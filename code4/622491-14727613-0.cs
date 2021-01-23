    var tasks = servers
        .Select(s => Task.Factory.StartNew(server => CallServer((string)server), s))
        .OrderByCompletion();
    foreach (var task in tasks)
    {
        if (task.Result)
        {
            Console.WriteLine("found");
            break;
        }
        Console.WriteLine("not found yet");
    }
    // cancel any outstanding tasks since the correct server has been found
