    ...
    void Email(string message){}
    
    void Log(string message){}
    
    void CallWebService(string message){}
    
    
    void RunMonitoringTask()
    {
        var task = Task.TaskFactory.StartNew(() =>
        {
            string message = Monitor();
            if( ShouldNotify(message))
               {
                  Email(mesasge);
                  Log(message);
                  CallWebService(message);
               }
        }
    )
    }
    ...
