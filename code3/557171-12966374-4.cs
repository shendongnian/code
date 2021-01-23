    public class CustomMarshalerType : ICustomMarshaler
    {
        public object MarshalNativeToManaged(IntPtr pNativeData)
        {
            return (ulong)Marshal.ReadIntPtr(pNativeData).ToInt64();
        }
        public IntPtr MarshalManagedToNative(object ManagedObj)
        {
            throw new InvalidOperationException();
        }
        public void CleanUpNativeData(IntPtr pNativeData)
        {
        }
        public void CleanUpManagedData(object ManagedObj)
        {
        }
        public int GetNativeDataSize()
        {
            return IntPtr.Size;
        }
    }
