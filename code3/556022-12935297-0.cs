    using System.Timers;
    var	oTimer = new Timer();
    
    	oTimer.Interval = 30000; // 30 second
    	oTimer.Elapsed += new ElapsedEventHandler(MyThreadFun);
    	oTimer.Start();    
    
    private static void MyThreadFun(object sender, ElapsedEventArgs e)
    {
        // inside here you read your query from the database
        // get the next email that must be send, 
        //  you send them, and mark them as send, log the errors and done.
    }
