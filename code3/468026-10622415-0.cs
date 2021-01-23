    //Stack containing the info to process
    Stack<string> infos = new Stack<string>();
    //Method for the thread
    void doTask()
    {
        while(true)
        {
            string info;
            //Threadsafe access to the stack
            lock (infos.SyncRoot)
            {
                //Exit the thread if no longer info to process
                if (infos.Count == 0) return;
                
                info = infos.Pop();
            }
            //Do the actual stuff on the info
            __DoStuff(info);
        }
    }
