    int tasks = 0; // keep track of number of active tasks
    object locker = new object(); // synchronization object
    foreach(var order1 in dtOrders.AsEnumerable())
    {
        lock(locker) tasks++; // added a new task
        var order = order1; // local copy to avoid data races
        ThreadPool.QueueUserWorkItem(
           o =>
           {          
                string orderNumber = order["OrderNumber"].ToString();
                string orderResult = SearchResultByOrderNumber(orderNumber);
                DataRow dr = dtResult.NewRow();
                dr["OrderNumber"] = orderNumber;
                dr["OrderResult"] = orderResult;
                lock(locker) // update shared data structure and signal termination
                {
                    dtResult.Rows.Add(dr);
                    tasks--;
                    Monitor.Pulse(locker);
                }                
           });
    }
    // barrier to wait for all tasks to finish
    lock(locker)
    {
       while(tasks > 0) Monitor.Wait(locker); 
    }
