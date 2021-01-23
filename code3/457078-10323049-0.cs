    //do this before you start spawning threads
    List<bool> successes = new List<bool>();
    ThreadPool.QueueUserWorkItem(
                new WaitCallback(ProcessStatuses.StartProcessing),
                new object[] {newProcess, allProcesses, successes}
                );
    
    //you MUST wait for all your threads to complete before proceeding!
    if(successes.Any(s => !s))
    {
        //update your error label
    }
    public static void StartProcessing(object data, Label lblError)
    {
        var dataArray = (object[3]) data;
        //if there is an error
        dataArray[2] = false;
    }
    
