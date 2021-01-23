    [DllImport("TestLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void DisplayHelloFromDLL(string a);
    static void Main ()
    {
        string a = "Hello";
        DisplayHelloFromDLL(a);
    }
