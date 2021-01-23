    class Container : IDisposable {
      private readonly IDisposable _field;
    
      public void Dipose() {
    
        // Don't want a using here.
        _field.Dispose();
      }
    }
