    public class Example
    {
      // ...
    
      // Depending on whether there are one or many instances of 
      // this class determines whether this needs to be static 
      // or not. If it needs to be static, use a static constructor.
      private object syncObject = new object();
    
      // ...
    
      void WriteToFile()
      {
        lock (syncObject)
        {
           // Do file IO
           // Now no two threads will attempt to access the file at the same time
        }
      }
    
      // ...
    }
