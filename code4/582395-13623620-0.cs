    public unsafe struct SInternalProcessData
    {
    	public ushort command;
    	[MarshalAs(UnmanagedType.ByValArray, SizeConst = PACKET_DATA_SIZE - 2)]
    	public fixed byte data[PACKET_DATA_SIZE - 2];
    };
    
    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public unsafe struct SMessageParameter
    {
    	[FieldOffset(0)]
    	public SInternalProcessData strInternalProcess;
    	[FieldOffset(0)]
    	[MarshalAs(UnmanagedType.ByValArray, SizeConst = PACKET_DATA_SIZE)]
    	public fixed byte data[PACKET_DATA_SIZE];
    };
	
    public const int PACKET_HEADER_SIZE = 17;
    public const int PACKET_BODY_SIZE = 12;
    public const int PACKET_COMPLETE_SIZE = 4204;
    public const int PACKET_DATA_SIZE = PACKET_COMPLETE_SIZE - PACKET_HEADER_SIZE - PACKET_BODY_SIZE;
    //value PACKET_DATA_SIZE = 4175	
