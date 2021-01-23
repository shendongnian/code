    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class SomeData
    {
        /// char[15]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 15)]
        public byte[] data = new byte[15];
        /// int[15]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 15)]
        public int[] prob = new int[15];
    }
