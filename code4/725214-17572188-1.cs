    for(int index = 0; index < MAX; index++) {
      var localIndex = index;
      Task.Run(async () => {
        await SomeAsynchronousTasks();
        var item = items[localIndex];
        item.DoSomeProcessing();
        if(b)
            AVolatileList[localIndex] = item;
        else
            AnotherVolatileList[localIndex] = item;
      }
    }
