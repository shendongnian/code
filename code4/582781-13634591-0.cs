    class SomeService
    {
      Task<string> GetSomeResult()
      {
        // Performing long-running operation to obtain the result
      }
    }
    
    class YourServiceConsumer
    {
      private void YourMethod()
      {
         Task<string> task = service.GetSomeResult();
      }
    }
