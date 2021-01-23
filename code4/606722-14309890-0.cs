    [Flags]
    public enum NumberEnum : byte
    {
        None = 0,
        One = 1,
        Two = 2,
        Three = 4,
        Four = 8,
        Five = 16,
        Six = 32
    };
    public string ExampleMethodWithNumberCombinationsAsAEnum(NumberEnum filterFlags = 0)
    {
     if ((filterFlags & NumberEnum.One) == NumberEnum.One)
     {
        //Do something with one
     }
    
     if (((filterFlags & NumberEnum.One) == NumberEnum.One) && ((filterFlags & NumberEnum.Two) == NumberEnum.Two))
     {
        //Do something with one & two
     }
    }
