    public static unsafe ulong ToULong(byte[] values)
    {
        byte* buffer = stackalloc byte[8];
        if (BitConverter.IsLittleEndian)
            Array.Reverse(values);
        System.Runtime.InteropServices.Marshal.Copy(values, 0, (IntPtr)buffer, values.Length);
        return *(ulong*)buffer;
    }
