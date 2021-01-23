    static class DynamicFilter
    {
        [Matcher] public static object HasName(string name) { return null; }
        public static bool HasName(dynamic filter, string name)
        {
            string passedName = filter.Name; //dynamic expression
            return name.Equals(passedName);
        }
    }
