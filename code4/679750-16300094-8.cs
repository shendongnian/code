    static byte[] bytes;
    static void Prep(TestStruct[] array)
    {
        int size = Marshal.SizeOf(typeof(TestStruct)) * array.Length;
        bytes = new byte[size];
        GCHandle gcHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
        var ptr = gcHandle.AddrOfPinnedObject();
        Marshal.Copy(ptr, bytes, 0, size);
        gcHandle.Free();
    }
    static void SlowWrite(BinaryWriter writer)
    {
        writer.Write(bytes);
    }
