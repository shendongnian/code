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
    
      private void AnalyzeBuffer()
      {
        while (true)
        {
          string data = buffer.Take();
          Console.WriteLine(data);
        }
      } 
    }
