    var taskA = new Task<string>(DoA);
    var taskB = new Task<string>(DoB);
    var taskC = new Task<string>( () => DoC(taskA.Result, taskB.Result));
    var taskCheckPoint = Task.WhenAll(taskA, taskB);
    var taskFollowUp = taskCheckPoint.ContinueWith(taskC);
    taskA.Start();
    taskB.Start();
    //now we return, instead of waiting.
