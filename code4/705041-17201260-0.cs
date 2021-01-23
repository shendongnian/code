    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_GET_STREAM_UNION
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 492, ArraySubType = UnmanagedType.I1)]
        public byte[] byUnion;
        public void Init()
        {
            byUnion = new byte[492];
        }
    }
    
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_STREAM_MODE
    {  
        public byte  byGetStreamType;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[]  byRes;
        public NET_DVR_GET_STREAM_UNION uGetStream;
        public void Init()
        {
            byGetStreamType = 0;
            byRes = new byte[3];
            uGetStream.Init();
        }
    }
