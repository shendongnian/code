    [Flags]
    private enum MemoryProtection: uint
    {
        NoAccess         = 0x000,
        Read             = 0x001,
        Write            = 0x002,
        Execute          = 0x004,
        Copy             = 0x008,
        Guard            = 0x010,
        NoCache          = 0x020,
        ReadOnly         = Read,
        ReadWrite        = (Read | Write),
        WriteCopy        = (Write | Copy),
        // etc.
        NoAccess         = 0x800
    }
