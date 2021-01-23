    //=======C-code======
    //type signature of callback function
    typedef int (__stdcall *FuncCallBack)(int, int);
    void SetWrappedCallback(FuncCallBack); //here default = __cdecl
    //======C# code======
    public delegate int FuncCallBack(int a, int b);   // here default = StdCall 
    [DllImport(@"PathToDll", CallingConvention = CallingConvention.Cdecl)]
    private static extern void SetWrappedCallback(FuncCallBack func);
