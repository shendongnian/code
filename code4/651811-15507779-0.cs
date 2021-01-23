    var task = System.Threading.Tasks.Task.Factory.StartNew(() =>
    {
      lock (toSaveIdentifiers)
      {
          FameMappingEntry.SaveFameDBMap(toSaveIdentifiers);
      }
    );
    int x = dosomething();
    task.Wait();
    return x;
                   
