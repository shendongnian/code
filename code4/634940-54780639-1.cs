    Task task = Task.Run(() =>             
    {                 
    	while (!token.IsCancellationRequested) {
    		 Console.Write("*");                      
    		Thread.Sleep(1000);                 
    	}           
    	token.ThrowIfCancellationRequested();               
    }, token);  
                
    try             
    {                
    	Console.WriteLine("Press enter to stop the task");                 
    	Console.ReadLine();                 
    	cancellationTokenSource.Cancel();                 
    	task.Wait();             
    } 
    catch (OperationCanceledExceptione ex)             
    {                 
    	Console.WriteLine(ex.Message);             
    }  
