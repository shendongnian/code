    while (true)
    {
    	int maxThreadsPerWorkerRole = 3;//assuming each worker role can handle 3 jobs simultaneously
    	var messages = Queue.GetMessages(3);//Get 3 messages from the queue
    	if (messages != null && messages.Count > 0)//Ensuring there is some work which needs to be done
    	{
    		var myTasks = new List<Task>();
    		for (int i=0; i<messages.Count; i++)
    		{
    			Job MyJob = Kernel.Get<Job>();//Get the job
    			var task = Task.Factory.StartNew(() => MyJob.Run(messages[i])); 
    			myTasks.Add(task);
    		}
    		Task.WaitAll(myTasks.ToArray());//Wait for all tasks to complete.
    		for (int i=0; i<messages.Count; i++)
    		{
    			//Write code to delete the message.
    		}
    		//Check if the queue is empty or not. If the queue is not empty, then repeat this loop
    		//Otherwise simply exit this loop.
    		if (Queue.RetrieveApproximateMessageCount() == 0)
    		{
    			break;
    		}
    	}
    }
