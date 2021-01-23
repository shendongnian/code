    public class WeeklyRegistry : Registry
    {
	    public WeeklyRegistry()
	    {            
		    Schedule<WeeklyTask>().ToRunEvery(1).Weeks(); // run WeeklyTask on a weekly basis           
	    }
    }
    
    public class WeeklyTask : ITask
    {
	    public void Execute()
	    {            
		    // call the method to run weekly here
	    }
    }
