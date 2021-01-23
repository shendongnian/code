    //Create a new timer that ticks every 5 min
    var t = new System.Timers.Timer (300000);
    
    //When a tick is elapsed
    t.Elapsed+=(object sender, System.Timers.ElapsedEventArgs e) => 
    {
    	//Start a new task (thread) that does something
    	System.Threading.Tasks.Task.Factory.StartNew(()=>
    	{
    		AutoSave();
    	});
    };
    //Start the timer
    t.Start();
