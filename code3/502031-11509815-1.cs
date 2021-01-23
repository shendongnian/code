    [DllImport("myDLL.dll")]
    private static extern int ChannelName(int x, int y, [In,Out] byte[] z);
    public static int ChannelName(int x, int y, out string result)
    {
        // There is no Marshal.ZeroAllocHGlobal method, so to get a zero-filled array
        //  we will allocate a managed one which zero-fills it.
        byte[] z = new byte[100];
        int ret = ChannelName(x, y, z);
        result = Encoding.ASCII.GetString(z);
        return ret;
    }
