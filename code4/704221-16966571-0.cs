    // C#
    public class Resource : IDisposable
    {
       private EmbeddedResource embedded;
    
       public Resource()
       {
          Console.WriteLine("allocating resource");
          embedded = new EmbeddedResource();
       }
    
       ~Resource()
       {
          Dispose(false);
       }
    
       protected virtual void Dispose(bool disposing)
       {
          Console.WriteLine("release resource");
          if (disposing)
          {
             embedded.Dispose();
          }
       }
    
       public void Dispose()
       {
          Dispose(true);
       }
    }
