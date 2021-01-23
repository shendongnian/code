    private void CreateLListener() {
        //....
        while(true) {
            ThreadPool.QueueUserWorkItem(Process, listener.GetContext());    
        }
    }
    void Process(object o) {
        var context = o as HttpListenerContext;
        // process request and make response
    }
