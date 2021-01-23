    class StructWrapper : IDisposable {
        public IntPtr Ptr { get; private set; }
        
        public StructWrapper(object obj ) {
             Ptr = Marshal.AllocHGlobal(Marshal.SizeOf(obj));
             Marshal.StructureToPtr(obj, ptr, false);
        }
    
        ~SturctWrapper() {
            if (Ptr != IntPtr.Zero) {
                Marshal.FreeHGlobal(Ptr);
                Ptr = IntPtr.Zero;
            }
        }
    
        public void Dispose() {
           Marshal.FreeHGlobal(Ptr);
           Ptr = IntPtr.Zero;
           GC.SuppressFinalize(this);
        }
    }
