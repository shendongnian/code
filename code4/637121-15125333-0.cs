    [Flags]
    public enum NumberEnum : byte
    {
        None = 0,
        One = 1,
        Two = 2,
        Three = 4
    };       
    
    public string GetRemainingEnumItem(NumberEnum filterFlags = 0)
    {  
     if (((filterFlags & NumberEnum.One) == NumberEnum.One) && ((filterFlags & NumberEnum.Two) == NumberEnum.Two))
     {
        //1 & 2 are selected so item 3 is what you want
     }
    
     if (((filterFlags & NumberEnum.One) == NumberEnum.One) && ((filterFlags & NumberEnum.Three) == NumberEnum.Three))
     {
        //1 & 3 are selected so item 2 is what you want
     }
    
     if (((filterFlags & NumberEnum.Three) == NumberEnum.Three) && ((filterFlags & NumberEnum.Two) == NumberEnum.Two))
     {
        //2 & 3 are selected so item 1 is what you want
     }
    }
