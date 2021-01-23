    enum Flags
    {
        A = 1,
        B = 2,
        C = 4
    }
    void Check(int flags)
    {
        bool isValid = Enum.IsDefined(typeof(Flags), flags);
        ...
    }
