    private class ReturnArrayMarshaller : ICustomMarshaler
    {
        public static ICustomMarshaler GetInstance(string cookie)
        {
            return new ReturnArrayMarshaller(cookie);
        }
        private readonly int byteCount;
        private ReturnArrayMarshaller(string cookie)
        {
            byteCount = int.Parse(cookie);
        }
        public void CleanUpManagedData(object ManagedObj) { throw new NotImplementedException(); }
        public void CleanUpNativeData(IntPtr pNativeData)
        {
            // release unmanaged return value if needed
        }
        public int GetNativeDataSize() { throw new NotImplementedException(); }
        public IntPtr MarshalManagedToNative(object ManagedObj) { throw new NotImplementedException(); }
        public object MarshalNativeToManaged(IntPtr pNativeData)
        {
            byte[] data = new byte[byteCount];
            Marshal.Copy(pNativeData, data, 0, data.Length);
            return data;
        }
    }
