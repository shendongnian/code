    public static class EnumExtensions
    {
        public static string ToNonPascalString(this Enum enu)
        {
           return Regex.Replace(enu.ToString(), "([A-Z])", " $1").Trim();
        }
        public T EnumFromString<T>(string value) where T : struct
        {
           string noSpace = value.Replace(" ", "");
           if (Enum.GetNames(typeof(T)).Any(x => x.ToString().Equals(noSpace)))
           {
               return (T)Enum.Parse(typeof(T), noSpace);
           }
           return default(T);
        }
    }
