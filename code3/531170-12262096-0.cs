    [System.Flags]
    public enum EnumType: int
    {
        None = 0,
        Black = 1,
        White = 2,
        Both = Black | White,
        Either = None | Both
    }
