    public static class EnumExtensions
    {
        public static string ToPascalString(this Enum enu)
        {
           return Regex.Replace(enu.ToString(), "([A-Z])", " $1").Trim();
        }
    }
