    [DllImport("kernel32.dll")]
    static extern void CopyMemory(IntPtr dst, IntPtr src, uint size);
    
    [StructLayout((LayoutKind.Sequential, Pack=1)]
    struct variable_t
    {    
        public int int0;
        public double double0;
        public int subdata_length;
        private IntPtr subdata;
        public SubData[] subdata
        {
            get
            {
                 SubData[] ret = new SubData[subdata_length];
                 GCHandle gcH = GCHandle.Alloc(ret, GCHandleType.Pinned);
                 CopyMemory(gcH.AddrOfPinnedObject(), subdata, (uint)Marshal.SizeOf(typeof(SubData))*subdata_length);
                 gcH.Free();
                 return ret;
            }
            set
            {
                 if(value == null || value.Length == 0)
                 {
                     subdata_length = 0;
                     subdata = IntPtr.Zero;
                 }else
                 {
                     GCHandle gcH = GCHandle.Alloc(value, GCHandleType.Pinned);
                     subdata_length = value.Length;
                     if(subdata != IntPtr.Zero)
                         Marshal.FreeHGlobal(subdata);
                     subdata = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(SubData))*subdata_length);
                     CopyMemory(subdata, gcH.AddrOfPinnedObject(),(uint)Marshal.SizeOf(typeof(SubData))*subdata_length);
                     gcH.Free();
                 }
            }
        }
    };
    [StructLayout((LayoutKind.Sequential, Pack=1)]
    sturct SubData
    {
        public int subInt;
        public double subDouble;
    };
