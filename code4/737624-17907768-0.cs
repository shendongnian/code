    public struct MyU32
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Bytes;
        public uint Value
        {
            get { return ((uint)Bytes[0] + Bytes[1] << 8 + Bytes[2] << 16 + Bytes[3] << 24); }
            set 
            { 
                Bytes[0] = (byte)(value & 0xFF);
                Bytes[1] = (byte)(value>>8 & 0xFF);
                Bytes[2] = (byte)(value>>16 & 0xFF);
                Bytes[3] = (byte)(value>>24 & 0xFF);
            }
        }
    }
