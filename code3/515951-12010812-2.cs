    var taskA = new Task<string>(DoA);
    var taskB = new Task<string>(DoB);
    var taskC = new Task<string>( () =>{
      taskA.Wait();
      taskB.Wait();
      DoC(taskA.Result, taskB.Result)
    });
    taskA.Start();
    taskB.Start();
    taskC.Start();
    //now we return, instead of waiting.
