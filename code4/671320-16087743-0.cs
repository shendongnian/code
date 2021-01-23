    Action<TraceEvent> action = delegate(TraceEvent data)
    {
      foreach (var name in data.PayloadNames)
      {
        Console.WriteLine("\t" + name + " -- " + data.PayloadByName(name));
      }
    };
