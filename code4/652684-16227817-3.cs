      public class AllocHGlobal : IDisposable
      {
        public readonly IntPtr Buffer;
        public AllocHGlobal(int len)
        {
          Buffer = Marshal.AllocHGlobal(len);
        }
        public AllocHGlobal(byte[] data) :
          this(data.Length)
        {
          Marshal.Copy(data, 0, Buffer, data.Length);
        }
    
        #region Implementation of IDisposable
    
        public void Dispose()
        {
          Marshal.FreeHGlobal(Buffer);
        }
    
        #endregion
      }
