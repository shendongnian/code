    var task1 = Task.Factory.StartNew(() =>
        {
           //some oepratation
        });
         var task2 = Task.Factory.StartNew(() =>
        {
           //some operations
        });
        Task.WaitAll(task1, task2);
