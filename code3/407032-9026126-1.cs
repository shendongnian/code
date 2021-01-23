            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct RM_CLIENT_DATA
        {
            public UInt16 wtype;
            AB   objEmbededStruct1;
            BB   objEmbededStruct2;
	    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 13)]
            char[]  szString; 
            public Data objMyUnion //this is the structure substituted for the union
            public int bExist;
	}
	
	//Union struct
	[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi)]
        public struct Data
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = FILE_NAME_LENGTH + 1)]
            [FieldOffset(0)]
            public char[] szString1
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = DOCS_LEN + 1)]
            [FieldOffset(0)]
            public char[] szString2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 134)]
            [FieldOffset(0)]
            public char[] szString3;
        }
	[structLayout(LayoutKind.Sequential, charset = charSet.Ansi)]
	public struct AB
	{
	    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            char[] szThisString1;
	    int IFlag1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 11)]
	    char[] szThisString2;
	}
	
	[structLayout(LayoutKind.Sequential, charset = charSet.Ansi)]
	public struct BB
	{
	    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public UInt32[] hEvents;
            public UInt32 dw;
            public int ithisFlag;
    	   
	}
