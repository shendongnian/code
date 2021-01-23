    DLL void __stdcall GetUserPass(char* &userName, char* &passWord)
    {
        userName = "ceva";
        passWord = "altceva";
    }
    [DllImport("myDLL.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
    private static extern void GetUserPass(ref IntPtr userName, ref IntPtr passWord);
    static void f()
    {
            IntPtr userNamePtr = new IntPtr();
            IntPtr passWordPtr = new IntPtr();
            GetUserPass(ref userNamePtr, ref passWordPtr);
            string userName = Marshal.PtrToStringAnsi( userNamePtr );
            string passWord = Marshal.PtrToStringAnsi( passWordPtr );
    }
