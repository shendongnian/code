    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal class SomeStruct
    {
       [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
       public string m_s1;             
       public UInt32 m_nS;             
       [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 512)]
       public string m_s2;             
       public UInt32 m_nP;
       [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 512)]
       public string m_s3;
    }
