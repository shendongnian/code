    private static Object locker= new Object();
    
    private static string SendRequestToServer(int id)
    { 
      lock(locker)
      {
        Task<HttpResponseMessage> response = client.GetAsync("some string");
        responseTask.ContinueWith(x => PrintResult(x));
        return "some new value";
      }
    }
