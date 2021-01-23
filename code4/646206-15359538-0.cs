    Task t = Task.Factory.StartNew(() =>
    {
       Console.WriteLine("I am the task");
       return "res1";
    });
    
    var genericTask = t as Task<string>; // genericTask will be non-null
    var result = genericTask.Result;     // and you can access the result
