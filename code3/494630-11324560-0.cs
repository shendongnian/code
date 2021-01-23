    public abstract class Publisher 
    {
          // if you wish to force implementation in derived class, make method abstract
          private abstract void Initialize();
          // if you wish optional implementation in derived class, make it virtual
          protected virtual void SendChangesToWeb() 
          {
             // ...
             webClient.Upload(address, data)
          }
          // if you wish that some step could not be changed from outside 
          private void LogSentChangesToDatabase() 
          {
             // ... save date time when was send and what was sent
          }
          // this sequence is the same for all derives, no point to duplicate 
          public void PublishUpdates() 
          {
               Initialize();
               SendChangesToWeb();
               LogSentChangesToDatabase();
          }
    }
