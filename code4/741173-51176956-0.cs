    public static class EnumExtensions
    {
        public static bool IsOneOf(this Enum enumeration, params Enum[] enums)
        {
            return enums.Contains(enumeration);
        }
    }
    // usage:
    if(Flow.IsOneOf(GameFlow.Normal, GameFlow.NormalNoMove))
