    if ( i% 10 == 0) //every tentth time we send a task out tou a thread
    {
       // clone your list before starting the task
       var listToProcess = new List<MyType>(list);
       list.Clear();
       Task.Factory.StartNew(() => WriteToDB(listToProcess)); 
    }
