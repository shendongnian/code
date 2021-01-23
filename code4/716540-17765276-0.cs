    public static class Ext
    {
        public static string addCondition(this string str, bool condition, string statement)
        {
            if (!condition)
                return str;
            return str + (!str.Contains(" WHERE ") ? " WHERE " : " ") + statement;
        }
        public static string cleanCondition(this string str)
        {
            if (!str.Contains(" WHERE "))
                return str;
            return str.Replace(" WHERE AND ", " WHERE ").Replace(" WHERE OR ", " WHERE ");
        }
    }
