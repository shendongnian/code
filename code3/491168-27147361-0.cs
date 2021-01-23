    List<FileMemberEntity> copy = new List<FileMemberEntity>(fileInfo);
    object sync = new Object();
    
    Parallel.ForEach<FileMemberEntity, List<FileMemberEntity>>(
          copy,
          () => { return new List<FileMemberEntity>(); },
          (itemInCopy, state, localList) =>
          {
             // here you can add or remove items from the fileInfo list
             localList.Add(itemInCopy);
             return localList;
          },
          (finalResult) => { lock (sync) copy.AddRange(finalResult); }
    ); 
    
     // do something
