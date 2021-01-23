    public sealed class MyCustomMarshaler : ICustomMarshaler
    {
        private static MyCustomMarshaler _instance = new MyCustomMarshaler();
        public void CleanUpManagedData(object o)
        {
        }
        public void CleanUpNativeData(IntPtr ptr)
        {
        }
        public int GetNativeDataSize()
        {
            return IntPtr.Size;
        }
        public IntPtr MarshalManagedToNative(object o)
        {
            return IntPtr.Zero;
        }
        public object MarshalNativeToManaged(IntPtr ptr)
        {
            return new MySafeHandle()
            {
                handle = ptr
            };
        }
        
        public static ICustomMarshaler GetInstance(string s)
        {
            return _instance;
        }
    }
