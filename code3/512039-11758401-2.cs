    private Task lastTask;
    public void TaskSpin(Func asyncMethod, object[] methodParameters)
    {
        ...
        if(lastTask == null)
            asyncTask = Task.Factory.StartNew<bool>(() => 
                asyncMethod(uiScheduler, methodParameters));
        else 
            asyncTask = lastTask.ContinueWith(t => 
                asyncMethod(uiScheduler, methodParameters));
        lastTask = asyncTask.ContinueWith(task =>
        {
            // Finish the processing update UI etc.
        }
        ...
    }
