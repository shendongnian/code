    public void RunAsync(Action onComplete, Action<Exception> errorHandler, params Action[] actions)
    {
        if (actions.Length == 0)
        {
            //what to do when no actions/tasks provided?
            onComplete();
            return;
        }
        List<Task> tasks = new List<Task>(actions.Length);
        foreach(var action in actions)
        {
            Task task = new Task(action);
            task.ContinueWith(t => errorHandler(t.Exception), TaskContinuationOptions.OnlyOnFaulted);
            tasks.Add(task);
        }
        //last task calls onComplete
        tasks[actions.Length - 1].ContinueWith(t => onComplete(), TaskContinuationOptions.OnlyOnRanToCompletion);
        //wire all tasks to execute the next one, except of course, the last task
        for (int i = 0; i <= actions.Length - 2; i++)
        {
            var nextTask = tasks[i + 1];
            tasks[i].ContinueWith(t => nextTask.Start(), TaskContinuationOptions.OnlyOnRanToCompletion);
        }
        tasks[0].Start();
    }
