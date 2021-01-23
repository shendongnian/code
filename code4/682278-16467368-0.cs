    class Program
    {
        static void Main(string[] args)
        {
            IntPtr hContext;
            SCardEstablishContext(0, IntPtr.Zero, IntPtr.Zero, out hContext);
            SCARD_READERSTATE[] rs = new SCARD_READERSTATE[1];
            rs[0].szReader = "\\\\?PnP?\\Notification";
            int result = SCardGetStatusChange(hContext, 100000000, rs, rs.Length);
            if (result == 0)
            {
                Console.WriteLine("Reader attached.");
            }
            else
            {
                Console.WriteLine("SCardGetStatusChange failed.");
            }
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        struct SCARD_READERSTATE
        {
            [MarshalAs(UnmanagedType.LPTStr)]
            public string szReader;
            public IntPtr pvUserData;
            public UInt32 dwCurrentState;
            public UInt32 dwEventState;
            public UInt32 cbAtr;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 36)]
            public byte[] rgbAtr;
        }
        [DllImport("winscard.dll", CharSet=CharSet.Auto)]
        static extern int SCardGetStatusChange(IntPtr hContext, int dwTimeout, [In, Out] SCARD_READERSTATE[] rgReaderStates, int cReaders);
        [DllImport("winscard.dll")]
        static extern int SCardEstablishContext(UInt32 dwScope, IntPtr pvReserved1, IntPtr pvReserved2, out IntPtr phContext);
    }
