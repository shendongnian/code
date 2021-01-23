    public class TestClass : IDisposable
    {
        private void !TestClass() { Debug.WriteLine("Finalized"); }
        private void ~TestClass() { Debug.WriteLine("Disposed"); }
    
        public sealed override void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    
        [HandleProcessCorruptedStateExceptions]
        protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool disposing)
        {
            if (disposing)
            {
                this.~TestClass();
            }
            else
            {
                try
                {
                    this.!TestClass();
                }
                finally
                {
                    base.Finalize();
                }
            }
        }
    
        protected override void Finalize()
        {
            this.Dispose(false);
        }
    }
