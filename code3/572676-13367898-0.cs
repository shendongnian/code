    IEnumerable<QueueInformation> infos = ...;
    foreach (var categoryGroup in infos.GroupBy(i => i.Category))
    {
      Console.WriteLine("Current category: {0}", categoryGroup.Key);
      foreach (var queueInfo in categoryGroup)
      {
        Console.WriteLine(queueInfo.Name /*...*/);
      }
      Console.WriteLine("==========================");
    }
