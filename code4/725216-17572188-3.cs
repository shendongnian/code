    for(int index = 0; index < MAX; index++) {
      var localIndex = index;
      Task.Run(async () => {
        await SomeAsynchronousTasks();
        var item = items[index];
        item.DoSomeProcessing();
        if(b)
            AVolatileList[index] = item;
        else
            AnotherVolatileList[index] = item;
      }
    }
