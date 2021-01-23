    [DllImport("TestDLL.dll", CallingConvention = CallingConvention.StdCall, ExactSpelling = true, EntryPoint = "?check@A@@SGHPAD00@Z")]
        public static extern int check(string x, string y, string z);
    
        [DllImport("TestDLL.dll", CallingConvention = CallingConvention.ThisCall, ExactSpelling = true, EntryPoint = "?checkInst@A@@QAEHPAD00@Z")]
        public static extern int checkInst(IntPtr theObject, string x, string y, string z);
