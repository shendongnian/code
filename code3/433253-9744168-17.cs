    internal static class NativeMethods
    {
        [DllImport("Reader2.dll")]
        public static extern unsafe short GetIDBuffer(
               IntPtr hCom, ref byte dataFlag, ref byte count, 
               byte* value, ref byte stationNum);
    }
    static unsafe int TestGetIDBuffer()
    {
        const int arraySize = 255;
        byte[] bytes = new byte[arraySize + 1];
        byte dataFlag = 0;
        byte count = arraySize;
        byte status = 0;
        int retval;
        fixed (byte* buffer = bytes)
        retval = NativeMethods.GetIdBuffer(
                 IntPtr.Zero, ref dataFlag, ref count, buffer, ref status);
        Debug.WriteLine(Encoding.ASCII.GetString(bytes));
        Debug.WriteLine(dataFlag);
        Debug.WriteLine(status);
        Debug.WriteLine(count);
        Debug.WriteLine(retval);
        return retval;
    }
