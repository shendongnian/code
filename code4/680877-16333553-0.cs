    var task = Task.Factory.StartNew<List<AccessDetails>>(() => this.GetAccessListOfMirror(mirrorId, null,"DEV"));        
    var task1 =  Task.Factory.StartNew<List<AccessDetails>>(() => this.GetAccessListOfMirror(mirrorId, null, "PROD"));  
    var allTasks = new Task[]{task, task1};
    Task.WaitAll(allTasks);
    var result = task.Result;
    var result1 = task1.Result;    
