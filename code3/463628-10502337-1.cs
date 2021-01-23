    public class Example
    {
      private BlockingCollection<string> buffer = new BlockingCollection<string>();
    
      public Example()
      {
        new Thread(ReadFromExternalDevice).Start();
        new Thread(AnalyzeBuffer).Start();
      }
    
      private void ReadFromExteneralDevice()
      {
        while (true)
        {
          string data = GetFromExternalDevice();
          buffer.Add(data);
          Thread.Sleep(200);
        }
      }
    
      private void BufferAnalyze()
      {
        while (true)
        {
          string data = buffer.Take(); // This blocks if nothing is in the queue.
          Console.WriteLine(data);
        }
      } 
    }
