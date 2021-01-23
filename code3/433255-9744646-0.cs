    [DllImport("Reader2.dll")]
    public static extern  short GetIDBuffer(IntPtr hCom, ref byte DataFlag, ref byte Count,**(type)** value , ref byte StationNum);
    static  void Main(string[] args)
    {
        byte count = 0, station = 1, flag = 0; //this right here is probably your problem
        IntPtr hcom = IntPtr.Zero;
