    /// <summary>
    /// Execute the command Asynchronously.
    /// </summary>
    /// <param name="command">string command.</param>
    public void ExecuteCommandAsync(string command)
    {
       try
       {
        //Asynchronously start the Thread to process the Execute command request.
        Thread objThread = new Thread(new ParameterizedThreadStart(ExecuteCommandSync));
        //Make the thread as background thread.
        objThread.IsBackground = true;
        //Set the Priority of the thread.
        objThread.Priority = ThreadPriority.AboveNormal;
        //Start the thread.
        objThread.Start(command);
       }
       catch (ThreadStartException objException)
       {
        // Log the exception
       }
       catch (ThreadAbortException objException)
       {
        // Log the exception
       }
       catch (Exception objException)
       {
        // Log the exception
       }
    }
