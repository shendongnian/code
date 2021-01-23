    struct Pin : IDisposable
    {
        public GCHandle pinHandle;
        public Pin(object o) { pinHandle = GCHandle.Alloc(o, GCHandleType.Pinned); }
        public void Dispose()
        {
            pinHandle.Free();
        }
    }
    static class ElementSize<T>
    {
        private static int CalcSize(T[] testarray)
        {
          using (Pin p = new Pin(testarray))
            return (int)(Marshal.UnsafeAddrOfPinnedArrayElement(testarray, 1).ToInt64()
                       - Marshal.UnsafeAddrOfPinnedArrayElement(testarray, 0).ToInt64());
        }
        static public readonly int Bytes = CalcSize(new T[2]);
    }
