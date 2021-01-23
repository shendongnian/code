    TaskCreationoptions op = TaskCreationOptions.AttachedToParent;
    Task.Factory.StartNew(() => 
    {
        var task1 = Task.Factory.StartNew (CallService(1));
        var task2 = Task.Factory.StartNew (CallService(2));
        var task3 = Task.Factory.StartNew (CallService(3));
    })
    .ContinueWith(ant => { SomeOtherselegate });
