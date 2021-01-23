    var toBeProcessed = new Queue<Dependency>(mgr.Dependencies);
    while(toBeProcessed.Count > 0)
    {
      var item = toBeProcessed.Dequeue();
    
      // loop
      
      // if a new dependency gets added that needs processing, just add it to the queue.
      toBeProcessed.Enqueue(newissue1);
    
    }
