    public static class Extension
    {
        public static string TrimBefore(this string me, string expression)
        {
            int index = me.IndexOf(expression);
            if (index < 0)
                return null;
            else
                return me.Substring(index);
        }
    }
