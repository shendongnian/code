    var taskOne = Task.Factory.StartNew(() =>
       {
           // Do Stuff
       });
    var taskTwo = Task.Factory.StartNew(() =>
       {
           // Do Other Stuff
       });
    Task.WaitAll(taskOne, taskTwo);
    // Quit
