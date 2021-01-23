    [DllImport("MyDll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern int SomeFunction(int parameter1, int parameter2);
    [DllImport("MyDll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern int SomeFunctionWithState(IntPtr ctx, int parameter1, int parameter2);
    [DllImport("MyDll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern IntPtr GetState();
    [DllImport("MyDll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern void FreeState(IntPtr);
