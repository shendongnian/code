      public class WaitCursor : IDisposable
      {
        public WaitCursor()
        {
          Application.UseWaitCursor = true;
        }
    
        public void Dispose()
        {
          Application.UseWaitCursor = false;
        }
      }
