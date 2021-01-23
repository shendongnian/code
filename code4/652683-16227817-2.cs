      public class TemporaryComObject
      {
        public static TemporaryComObject<T> Wrap<T>(T com) where T : class
        {
          return new TemporaryComObject<T>(com);
        }
      }
    
      public class TemporaryComObject<T> : IDisposable where T : class
      {
        public TemporaryComObject(T com)
        {
          Com = com;
        }
    
        public T Com { get; private set; }
    
        #region IDisposable Members
    
        public void Dispose()
        {
          if (Com != null)
          {
            Marshal.FinalReleaseComObject(Com);
            Com = null;
          }
        }
    
        #endregion
      }
