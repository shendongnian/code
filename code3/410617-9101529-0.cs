    public class FirstClass : IDisposable {
      private bool isDisposed;
      public FirstClass() {
        isDisposed = false;
      }
      public void Dispose() {
        _logger.Info("FirstClass is done.");
        isDisposed = true;
      }
      public void Method1() {
        while (!isDisposed) {
          // your code here
        }
      }
      
    }
