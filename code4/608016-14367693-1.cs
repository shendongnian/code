    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct some_header {
    
    /// uint8_t->unsigned char
    public byte version;
    
    /// uint8_t->unsigned char
    public byte type;
    
    /// uint16_t->unsigned int
    public uint length;
    
    /// uint32_t->unsigned int
    public uint id;
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet=System.Runtime.InteropServices.CharSet.Ansi)]
    public some_struct {
    
    
    public some_header header;
    
    /// uint64_t->unsigned int
    public uint xxx;
    
    /// uint32_t->unsigned int
    public uint xxx2;
    
    /// uint8_t->unsigned char
    public byte xxx3;
    
    /// uint8_t->unsigned char
    public byte xxx4;
    
    /// uint8_t[2]
    [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst=2)]
    public string pad;
    
    /// uint32_t->unsigned int
    public uint xxx5;
    
    /// uint32_t->unsigned int
    public uint xxx6;
    }
