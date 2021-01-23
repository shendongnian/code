    [Flags]
    public enum FlagTest
    {
        None = 0,
        Read = 1,
        Write = Read * 2,
        Delete = Write * 2,
        ReadWrite = Read|Write
    }
