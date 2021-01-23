    static class ArrayCaster
    {
        [StructLayout(LayoutKind.Explicit)]
        private struct Union
        {
            [FieldOffset(0)]
            public Byte[] Bytes;
            [FieldOffset(0)]
            public UInt32[] UInt32s;
        }
        static unsafe int UInt32Id
        {
            get
            {
                fixed (UInt32* pUints = new UInt32[1])
                {
                    var pBytes = (Byte*)pUints;
                    return *(int*)(pBytes - 8);
                }
            }
        }
        static unsafe void SetSizeAndId(
            byte[] bytes,
            int newSize, int newId,
            out int oldSize, out int oldId)
        {
            fixed (Byte* pBytes = bytes)
            {
                int* size = (int*)(pBytes - 4);
                oldSize = *size;
                *size = newSize;
                int* id = (int*)(pBytes - 8);
                oldId = *id;
                *id = newId;
            }
        }
        public static unsafe void WithBytesAsUInt32s(
            Byte[] bytes, Action<UInt32[]> withUints)
        {
            if (bytes.Length % sizeof(UInt32) != 0) throw new ArgumentException();
            Union u = new Union { Bytes = bytes };
            int origSize, origId;
            SetSizeAndId(bytes, bytes.Length / sizeof(UInt32), UInt32Id,
                         out origSize, out origId);
            try
            {
                withUints(u.UInt32s);
            }
            finally
            {
                SetSizeAndId(bytes, origSize, origId, out origSize, out origId);
            }
        }
    }
