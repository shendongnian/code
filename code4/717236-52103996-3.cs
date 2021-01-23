    public class GCHandleProvider : IDisposable
    {
        public GCHandleProvider(IEnumerable<IntPtr> target)
        {
            Handle = target.ToGcHandle();
        }
        public IntPtr Pointer => Handle.ToIntPtr();
        public GCHandle Handle { get; }
        private void ReleaseUnmanagedResources()
        {
            if (Handle.IsAllocated) Handle.Free();
        }
        public void Dispose()
        {
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }
        ~GCHandleProvider()
        {
            ReleaseUnmanagedResources();
        }
    }
