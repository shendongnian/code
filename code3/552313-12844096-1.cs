    private BlockingCollection queue;
    public void Start() 
    {
        queue = new BlockingCollection<string[]>();
        Task.Factory.StartNew(() => { 
            while(!queue.IsCompleted) 
            { 
                var item = queue.Take(); 
                //add to listview and control speed 
            } 
        });
        Start.Whatever.Produces.Items();
        //when all items added to queue.
        queue.CompleteAdded();
    }
    private void AddnewItemToListView(...) 
    {
        var row = ...;
        queue.Add(row);
    }
    
