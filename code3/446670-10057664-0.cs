    class MyApplicationContext : ApplicationContext 
    {
    	[STAThread]
        static void Main(string[] args) 
        {
            // Create the MyApplicationContext, that derives from ApplicationContext,
            // that manages when the application should exit.
            MyApplicationContext context = new MyApplicationContext();
    
            // Run the application with the specific context. It will exit when
            // the task completes and calls Exit().
            Application.Run(context);
        }
    	
    	Task backgroundTask;
    	
        // This is the constructor of the ApplicationContext, we do not want to 
        // block here.
    	private MyApplicationContext() 
    	{
    		backgroundTask = Task.Factory.StartNew(BackgroundTask)
    		backgroundTask.ContinueWith(TaskComplete);
    	}
        // This will allow the Application.Run(context) in the main function to 
        // unblock.
        private void TaskComplete(Task src)
    	{
    	    this.Exit();
    	}
    	
        //Perform your actual work here.
    	private void BackgroundTask
    	{
    		//Stuff
    		Sendkeys.Send("{RIGHT}");
    		//More stuff
    	}
    }
