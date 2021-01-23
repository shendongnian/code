    var tasks = Enumerable.Range(0, MAX).Select(index =>
      Task.Run(async () => {
        await SomeAsynchronousTasks();
        var item = items[localIndex];
        item.DoSomeProcessing();
        if(b)
            AVolatileList[localIndex] = item;
        else
            AnotherVolatileList[localIndex] = item;
      }));
    await Task.WhenAll(tasks);
