    class StructWrapper : IDisposable {
        public IntPtr Ptr { get; private set; }
        
        public StructWrapper(object obj) {
             if (Ptr != null) {
                 Ptr = Marshal.AllocHGlobal(Marshal.SizeOf(obj));
                 Marshal.StructureToPtr(obj, ptr, false);
             }
             else {
                 Ptr = IntPtr.Zero;
             }
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
        public static implicit operator IntPtr(StructWrapper w) {
            return w.IntPtr;
        }
    }
