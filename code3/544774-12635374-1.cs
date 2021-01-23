    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct TREC_DATA
    {
          public byte ID;
          [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
          public byte[] MAC_ADDRESS;
          public uint fieldCard;
          public short fieldSI;
          public ushort fieldW;
          [MarshalAs(UnmanagedType.AnsiBstr)]
          public string SERIAL_NUMBER;
          public float fieldSingle;
          [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
          public byte[] fieldArrOfB;    
    } 
