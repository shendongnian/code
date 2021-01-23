    internal static class NativeMethods
    {
        [DllImport("Reader2.dll")]
        public static extern unsafe short GetIDBuffer(
               IntPtr hCom, ref byte dataFlag, ref byte count, 
               byte* value, ref byte stationNum);
    }
    internal unsafe struct TestStruct
    {
        private const int ArraySize = 255;
        public fixed byte Bytes [ArraySize];
        public int TestGetIDBuffer()
        {
            byte dataFlag = 0;
            byte count = ArraySize;
            byte stationNum = 0;
            IntPtr hCom = IntPtr.Zero;  // replace this with a valid handle value
            fixed (byte* buffer = Bytes)
            {
                return NativeMethods.GetIDBuffer(
                    hCom, ref dataFlag, ref count, buffer, ref stationNum);
            }
        }
    }
