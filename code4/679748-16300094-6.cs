    static byte[] bytes;
    static void Prep(TestStruct[] array)
    {
        int size = Marshal.SizeOf(typeof(TestStruct)) * array.Length;
        bytes = new byte[size];
        GCHandle gcHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
        var ptr = new IntPtr(gcHandle.AddrOfPinnedObject().ToInt64());
        Marshal.Copy(ptr, bytes, 0, size);
    }
    static void SlowWrite(BinaryWriter writer, TestStruct[] array, int offset, int count)
    {
        writer.Write(bytes);
    }
