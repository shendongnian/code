    private static IntPtr AllocDelphiString(string str)
    {
        byte[] unicodeData = Encoding.Unicode.GetBytes(str);
        int bufferSize = unicodeData.Length + 6;
        IntPtr hMem = Marshal.AllocHGlobal(bufferSize);
        Marshal.WriteInt32(hMem, 0, unicodeData.Length); // prepended length value
        for (int i = 0; i < unicodeData.Length; i++)
            Marshal.WriteByte(hMem, i + 4, unicodeData[i]);
        Marshal.WriteInt16(hMem, bufferSize - 2, 0); // null-terminate
        return new IntPtr(hMem.ToInt64() + 4);
    }
