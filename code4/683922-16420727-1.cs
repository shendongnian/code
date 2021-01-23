    // Change to Task.Factory.StartNew depending on .NET version
    var userTask = Task.Run(() => service.DoAbc());
    var productsTask = Task.Run(() => service.DoDef());
    
    Task.WaitAll(userTask, productsTask);
    
    users = userTask.Result;
    products = productsTask.Result;
