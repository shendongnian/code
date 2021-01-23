        var taskA = Task.Factory.StartNew(WorkA);
        var taskB = Task.Factory.StartNew(WorkB);
        var allTasks = new[] { taskA, taskB };
        taskA.Wait();
        taskB.Wait();
        if (taskA.Status == TaskStatus.RanToCompletion && taskB.Status == TaskStatus.RanToCompletion)
            Task.Factory.ContinueWhenAll(allTasks, tasks => FinalWork());
        else
            //do something
