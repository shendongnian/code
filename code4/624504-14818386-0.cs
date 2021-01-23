    public class MyCustomMarshaler : ICustomMarshaler
    {
        public static ICustomMarshaler GetInstance(String cookie)
        {
            return new MyCustomMarshaler();
        }
        public IntPtr MarshalManagedToNative(Object ManagedObj)
        {
            MyClassWrapper val = ManagedObj as MyClassWrapper;
            return val.ptrToNativeObj;
        }
        ...
     }
     [return: MarshalAs(UnmanagedType.CustomMarshaler,MarshalType = "MyCustomMarshaler")]
     public delegate MyClassWrapper CallbackDotNet();
