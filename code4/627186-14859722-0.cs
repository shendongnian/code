    public class DAL_Base<T> where T : IDisposable, new() {
    
      public DAL_Base() { // <= this should work
        // initialize items that will be used in all derived classes
      }
    
    }
