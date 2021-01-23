    internal static class NativeMethods
    {
        [DllImport("MyDll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern SomeSafeHandle CreateSomeState();
        [DllImport("MyDll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SomeFunction(SomeSafeHandle handle,
                                              int parameter1,
                                              int parameter2);
        [DllImport("MyDll.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int FreeSomeState(IntPtr handle);
    }
