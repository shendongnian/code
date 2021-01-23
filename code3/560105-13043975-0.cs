    public static class EnumExtensions
    {
        public static string D2(this Enum e)
        {
            return e.ToString("D").PadLeft(2, '0');
        }
    }
