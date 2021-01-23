    [Flags]
    public enum GetItemOptions
    {
        Read = 0x1,
        Unread = 0x2,
        All = 0x1 | 0x2,
        SortByOldest = 0x4,
        SortByLatest = 0x8
    }
