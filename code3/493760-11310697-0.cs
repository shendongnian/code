    [StructLayout(LayoutKind.Sequential)]
    public struct MPLOT 
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
        public double []    price;
        public int          streamSubset;
    } 
    [DllImport("dllname.dll", CallingConvention=CallingConvention.Cdecl)]
    public static extern void cFunction(
        ref MPLOT mPlot
    );
