    class Program
        {
            [DllImport("crypto.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool MsgEncode(string pIn, out IntPtr pOut);
        
            [DllImport("crypto.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
            public static extern void BlockFree(IntPtr p);
            
            static void Main(string[] args)
            {
                IntPtr pOut;
    
                string encode = "admin";
                string encoded = "";
    
    
                if (MsgEncode(encode, out pOut))
                    encoded = Marshal.PtrToStringAnsi(pOut);
                BlockFree(pOut);
    
                Console.WriteLine("String Encoded '" + encode + "' : " + encoded);
            }
