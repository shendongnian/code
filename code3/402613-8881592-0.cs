    private ManualResetEvent waitHandle;
    private object syncRoot = new object();
    private bool isRunning = false;
    void CreateThread()
    {
        this.waitHandle = new ManualResetEvent(false);
        isRunning = true; // Set to false to kill the thread
        System.Threading.Thread t = new Thread(new ThreadStart(QueueCometWaitRequest_WaitCallback));         
        t.IsBackground = false; 
        t.Start();
    }
    void PushData()
    {
        // On incoming data, push data into the processRequest queue and set the waithandle
        lock(syncRoot)
        {
            processRequest.Add(/* ... your data object to process. Assumes this is a queue */);
            waitHandle.Set(); // Signal to the thread there is data to process
        }
    }
    void QueueCometWaitRequest_WaitCallback() 
    {    
        while (isRunning)    
        {       
            // Waits here using 0% CPU until the waitHandle.Set is called above
            this.waitHandle.WaitOne();
            
            // Ensures no-one sets waithandle while data is being processed and
            // subsequently reset
            lock(syncRoot)
            {
                for (int i = 0; i < processRequest.Length; i++)           
                {                        
                    // Process the message. 
                    // What's the type of processRequest? Im assuming a queue or something     
                }       
                // Reset the Waithandle for the next requestto process
                this.waitHandle.Reset();
            }
        }        
    } 
