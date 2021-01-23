    class Result
    {
       public object Data { get; set; }
    }
    
    List<Work> WorkToDo = // Some population call
    List<Result> Results = new List<Result>();
    foreach (Work Item in WorkToDo)
    {
        Result Result = new Result();
        Results.Add(Result);
        System.Threading.Tasks.Task.Factory.StartNew(
            () => { Result.Data = "Hello World."; });
    }
