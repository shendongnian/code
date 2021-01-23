    var task = Task.Factory.StartNew<List<AccessDetails>>(() => GetAccessListOfMirror(mirrorId,server))
    .ContinueWith(tsk => ProcessResult(tsk));
    
    private void ProcessResult(Task task)
    {
        var result = task.Result;
    }
