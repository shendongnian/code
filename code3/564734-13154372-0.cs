    you can use signaling constructs to achieve the desired effect. 
    static ManualResetEvent mre = new ManualResetEvent(false);
    var Task1=Task.Factory.StartNew(() =>
    {
    	Console.WriteLine("Executing Task 1");
    	Thread.Sleep(2000);//A Long running operation
    	Console.WriteLine("Task 1 Completed");
    	mre.Set();//signal the task completion to task 2.
    });
    
    
    var Task2=Task.Factory.StartNew(() =>
    {
    	if (!Task1.IsCompleted)//check if task1 is completed.
    	{
    		mre.WaitOne();//wait until Task 1 Completes
    		Console.WriteLine("Executing Task 2");
    		Thread.Sleep(2000);
    		Console.WriteLine("Task 2 Completed");    
                  doSomeTask();
    	}
         else{//Task 1 is already completed
                  doSomeTask();
        }
    
    });
