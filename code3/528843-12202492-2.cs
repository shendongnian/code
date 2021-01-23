    IAsyncResult result = command.BeginExecuteReader();
    
    while (!result.IsCompleted)
    {
       System.Threading.Thread.Sleep(10);
    }
    
    command.EndExecuteReader(result);
