    if(messages.Length > 0)
    {
    	Task task = new Task(t => Console.WriteLine(messages[0]));
    
    	for(int i = 1; i < messages.Length; i++)
    	{
    		task = task.ContinueWith(t => Console.WriteLine(messages[i]));
    	}
    	task.Start();
    }
