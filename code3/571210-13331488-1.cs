    bool moreData = true;
    while(moreData){
        // Go get the next page of data ...
        moreData = TryGetNextPage();
        // spin up the tasks
        List<Task> tasks = new List<Tasks>();
        for(int i = 0; i < maxLoops ; i++){
           Task t = Task.Factory.StartNew(() => { // your action } );
           tasks.Add(t);
         }
         
         Task.WaitAll(tasks.ToArray());
     }
       
