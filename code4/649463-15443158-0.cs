    public class Csv : IDisposable { 
      ...
      public void Dispose() { 
        streamReader.Dispose();
        streamWriter.Dispose();
      }
    }
