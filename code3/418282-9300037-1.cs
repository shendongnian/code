    public static class EnumExtensions
    {
        public static bool In(this Enum value, params Enum[] values)
        {
            return values.Contains(value);
        }
    }
