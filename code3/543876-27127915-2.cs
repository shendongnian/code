    var resultCollection = new List<string>();
    object localLockObject = new object();
    
    Parallel.ForEach<string, List<string>>(
          words,
          () => { return new List<string>(); },
          (word, state, localList) =>
          {
             localList.Add(AddB(word));
             return localList;
          },
          (finalResult) => { lock (localLockObject) resultCollection.AddRange(finalResult); }
    ); 
    
    // Do something with resultCollection here
