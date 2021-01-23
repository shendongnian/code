    public partial class MyService : ServiceBase
    {
        private System.Threading.Thread myWorkingThread;
        private System.Timers.Timer myTimer = new System.Timers.Timer();
    
        // [...] Constructor, etc
        protected override void OnStart(string[] args)
        {
            // Do other initialization stuff...
    
            // Create the thread and tell it what is to be executed.
            myWorkingThread = new System.Threading.Thread(PrepareTask);
    
            // Start the thread.
            myWorkingThread.Start();
        }
        
        // Prepares the timer, sets the execution interval and starts it.
        private void PrepareTask()
        {
            // Set the appropiate handling method.
            myTimer.Elapsed += new System.Timers.ElapsedEventHandler(myTimer_Elapsed);
            
            // Set the interval time in millis. E.g.: each 60 secs.
            myTimer.Interval = 60000;
            
            // Start the timer
            myTimer.Start();
    
            // Suspend the thread until it is finalised at the end of the life of this win-service.
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
        }
    
        void myTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // Get the date and time and check it agains the previous variable value to know if
            // the time to change the "Mode" has come.
            // If does, do change the mode...
            EvalutateChangeConditions();
        }
    
        // Core method. Get the current time, and evaluate if it is time to change
        void EvalutateChangeConditions()
        {
            // Retrieve the config., might be from db? config file? and
            // set mode accordingly.
        }
        protected override void OnStop()
        {
            // Cleaning stuff...
        }
    }
