    [StructLayout(LayoutKind.Sequential)]
    public class connectOptions
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst=4, ArraySubType=UnmanagedType.U1)]
        public byte[] struct_id;
        public Int32 struct_version;
        public Int32 keepAliveInterval;
        public Int32 cleansession;
        public Int32 reliable;
        public willOptions will;
        public string username;
        public string password;
        public Int32 connectTimeout;
        public Int32 retryInterval;
    
        public connectOptions()
        {
            struct_id = Encoding.ASCII.GetBytes("WXYZ");
            struct_version = 0;
            keepAliveInterval = 20;
            cleansession = 1;
            reliable = 0;
            username = string.Empty;
            password = string.Empty;
            connectTimeout = 10;
            retryInterval = 1;
            will = null;
        }
    }
