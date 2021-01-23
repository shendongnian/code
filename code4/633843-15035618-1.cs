    public class Example
    {
      private bool signal = false;
    
      void ThreadA()
      {
        while (!signal);
        signal = false;
      }
    
      void ThreadB()
      {
        signal = true;
        while (signal);
      }
    }
