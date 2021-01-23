    ConcurrentQueue<Item> queue = new ...;
    
    //timer pulls every 100ms or so
    var timer = new Timer(_ => {
     var localItems = new List<Item>();
     while(queue.TryDequeue(...)) { localItems.Add(...); }
     if(localItems.Count != 0) { pushToUI(localItems); }
    });
    //producer pushes unlimited amounts
    new Thread(() => { while(true) queue.Enqueue(...); });
