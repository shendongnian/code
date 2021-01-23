    ...
    void Email(string message){}
    
    void Log(string message){}
    
    void CallWebService(string message){}
    
    
    void Monitor()
    {
        while(true)
        {
              string message = Monitor();
              if(ShouldNotify(message))
              { 
                  var task = Task.TaskFactory.StartNew(() =>
                  {
                      Email(mesasge);
                      Log(message);
                      CallWebService(message);
                  }
             }
        }
    )
    }
    ...
