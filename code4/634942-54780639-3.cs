    Task task = Task.Run(() =>             
    {                 
    	while (!token.IsCancellationRequested) {
    		 Console.Write("*");                      
    		Thread.Sleep(1000);                 
    	}           
    	token.ThrowIfCancellationRequested();               
    }, token)
    .ContinueWith(t =>
     {
          t.Exception?.Handle(e => true);
          Console.WriteLine("You have canceled the task");
     },TaskContinuationOptions.OnlyOnCanceled);  
                
    try             
    {                
    	Console.WriteLine("Press enter to stop the task");                 
    	Console.ReadLine();                 
    	cancellationTokenSource.Cancel();                 
    	task.Wait();             
    } 
    catch (AggregateException ex)             
    {                 
    	Console.WriteLine(ex.Message);             
    }  
