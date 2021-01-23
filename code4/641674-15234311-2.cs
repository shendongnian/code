    public static class EnumExtensions
    {
        public static string ToNonPascalString(this Enum enu)
        {
           return Regex.Replace(enu.ToString(), "([A-Z])", " $1").Trim();
        }
    }
