    [StructLayout(LayoutKind.Sequential)]
    public struct emxArray_real_T
    {
        public IntPtr data;
        public IntPtr size;
        public int allocatedSize;
        public int numDimensions;
        [MarshalAs(UnmanagedType.U1)]
        public bool canFreeData;
    }
    public class emxArray_real_T_Wrapper : IDisposable
    {
        private emxArray_real_T value;
        private GCHandle dataHandle;
        private GCHandle sizeHandle;
        public emxArray_real_T Value {
            get { return value; } 
        }
        public emxArray_real_T_Wrapper(double[] data)
        {
            dataHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
            value.data = dataHandle.AddrOfPinnedObject();
            sizeHandle = GCHandle.Alloc(new int[] { data.Length }, GCHandleType.Pinned);
            value.size = sizeHandle.AddrOfPinnedObject();
            value.allocatedSize = data.Length;
            value.numDimensions = 1;
            value.canFreeData = false;
        }
        public void Dispose()
        {
            dataHandle.Free();
            sizeHandle.Free();
            GC.SuppressFinalize(this);
        }
        ~emxArray_real_T_Wrapper()
        {
            Dispose();
        }
    }
