        enum EnumSourceType
        {
            Val1 = 0,
            Val2 = 1,
            Val3 = 2,
            Val4 = 4,
        }
 
        enum EnumTargetType
        {
            Targ1,
            Targ2,
            Targ3,
            Targ4,
        }
        Dictionary<EnumSourceType, EnumTargetType> SourceToTargetMap = new Dictionary<EnumSourceType, EnumTargetType>
        {
            {EnumSourceType.Val1, EnumTargetType.Targ1},
            {EnumSourceType.Val2, EnumTargetType.Targ2},
            {EnumSourceType.Val3, EnumTargetType.Targ3},
            {EnumSourceType.Val4, EnumTargetType.Targ4},
        };
        Console.WriteLine( SourceToTargetMap[EnumSourceType.Val1] )
